using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Text;
using System.Threading.Tasks;

public class OrderConsumer
{
	private const string HostName = "localhost";
	private const string QueueName = "orderLogQueue";
	private readonly IMongoCollection<BsonDocument> _orderCollection;

	public OrderConsumer(string connectionString, string databaseName)
	{
		var client = new MongoClient(connectionString);
		var database = client.GetDatabase(databaseName);
		_orderCollection = database.GetCollection<BsonDocument>("OrderLog");
	}

	public static void Main(string[] args)
	{
		var consumer = new OrderConsumer("mongodb://localhost:27017", "Tesodev");
		consumer.StartConsuming();
	}

	public void StartConsuming()
	{
		var factory = new ConnectionFactory() { HostName = HostName };
		using var connection = factory.CreateConnection();
		using var channel = connection.CreateModel();

		channel.QueueDeclare(queue: QueueName,
			durable: false,
			exclusive: false,
			autoDelete: false,
			arguments: null);

		var consumer = new EventingBasicConsumer(channel);
		consumer.Received += async (model, ea) =>
		{
			var body = ea.Body.ToArray();
			var message = Encoding.UTF8.GetString(body);
			Console.WriteLine("Mesaj alındı: {0}", message);

			// Sipariş logunu MongoDB'ye kaydet
			var document = BsonDocument.Parse(message);
			await _orderCollection.InsertOneAsync(document);

			Console.WriteLine("Sipariş logu MongoDB'ye kaydedildi.");
		};

		channel.BasicConsume(queue: QueueName,
			autoAck: true,
			consumer: consumer);
	}
}