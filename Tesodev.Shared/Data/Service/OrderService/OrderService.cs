using MongoDB.Driver;
using System.Net;
using Newtonsoft.Json;
using Tesodev.Shared.Data.Dto;
using Tesodev.Shared.Data.Enum;
using Tesodev.Shared.Data.Extensions;
using System.Net.Mail;

namespace Tesodev.Shared.Data.Service.OrderService
{
	public interface IOrderService
	{
		Task<Order> AddOrder(OrderAddDto orderAdd, string customerName, string productName);
		Task<string> DeleteOrder(string id);
		Task<List<OrderDto>> GetOrder();
		Task<OrderDto> GetOrderById(string id);
	}
	public class OrderService : IOrderService
	{
		public async Task<Order> AddOrder(OrderAddDto orderAdd, string customerName, string productName)
		{
			var db = DBConnectionExtension.MongoDBConnection();
			var dbOrder = db.GetCollection<Order>("Orders");
			var cust = new Customer();
			var prod = new Product();

			var dbCustomer = db.GetCollection<Customer>("customers");
			var listCustomer = await dbCustomer.Find(x => true).ToListAsync();

			var dbProduct = db.GetCollection<Product>("Product");
			var listProduct = await dbProduct.Find(x => true).ToListAsync();

			foreach (var customer in listCustomer)
			{
				if (customer.Name == customerName)
				{
					cust = customer;
				}
			}

			foreach (var product in listProduct)
			{
				if (product.Name == productName)
				{
					prod = product;
				}
			}


			Order response = new Order()
			{
				CustomerId = cust.Id.ToString(),
				Price = orderAdd.Price,
				Quantity = orderAdd.Quantity,
				Status = StatusEnum.Status.Successful.ToString(),
				Adress = cust.Adress,
				Product = prod

			};
			if (response != null)
			{
				await dbOrder.InsertOneAsync(response);
				SendMailOrder(response.ToString());
			}

			return response;
		}

		public async Task<string> DeleteOrder(string id)
		{
			var db = DBConnectionExtension.MongoDBConnection().GetCollection<Order>("Orders");
			await db.DeleteOneAsync(x => x.Id.ToString() == id);
			return HttpStatusCode.Accepted.ToString();
		}

		public async Task<List<OrderDto>> GetOrder()
		{
			var db = DBConnectionExtension.MongoDBConnection();
			var dbOrder = db.GetCollection<Order>("Orders");
			var listOrder = new List<OrderDto>();

			var cus = await dbOrder.Find(x => true).ToListAsync();

			if (dbOrder != null)
			{
				foreach (var order in cus)
				{
					var orderModel = new OrderDto()
					{
						Adress = order.Adress,
						CustomerId = order.CustomerId,
						Price = order.Price,
						Product = order.Product,
						Quantity = order.Quantity,
						Status = order.Status
					};
					listOrder.Add(orderModel);
				}
			}

			if (listOrder != null)
			{
				return listOrder;
			}

			return new List<OrderDto>();
		}

		public async Task<OrderDto> GetOrderById(string id)
		{
			var db = DBConnectionExtension.MongoDBConnection().GetCollection<Order>("Product");
			var order = JsonConvert.DeserializeObject<OrderDto>(JsonConvert.SerializeObject(db.Find(x => x.Id.ToString() == id).ToListAsync()));

			return order;
		}

		public void SendMailOrder(string? response)
		{
			var ePosta = new MailMessage();
			ePosta.From = new MailAddress("send@omercebi.com");
			ePosta.Subject = "Order Information";
			ePosta.Body = response;

			SmtpClient smtp = new SmtpClient();
			smtp.Credentials = new System.Net.NetworkCredential("denememail6154@gmail.com", "password");
			smtp.Port = 25;
			smtp.Host = "smtp.denememail.com";
			smtp.EnableSsl = true;

			smtp.SendAsync(ePosta, (object)ePosta);
			smtp.Send(ePosta);
		}
	}
}