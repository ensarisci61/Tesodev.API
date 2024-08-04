using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver;

namespace Tesodev.Shared.Data.Extensions
{
	public class DBConnectionExtension
	{
		public static IMongoDatabase MongoDBConnection()
		{
			var settings = new MongoClientSettings()
			{
				Scheme = ConnectionStringScheme.MongoDB,
				Server = new MongoServerAddress("localhost", 27017)
			};
			// Creates a new client and connects to the server
			var client = new MongoClient(settings);

			IMongoDatabase db = client.GetDatabase("Tesodev");

			return db;
		}
	}
}
