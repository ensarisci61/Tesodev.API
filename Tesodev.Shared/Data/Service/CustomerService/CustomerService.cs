using System.Net;
using MongoDB.Driver;
using System.Reflection.Metadata;
using MongoDB.Bson;
using Newtonsoft.Json;
using Tesodev.Shared.Data.Dto;
using Tesodev.Shared.Data.Extensions;

namespace Tesodev.Shared.Data.Service.CustomerService
{
	public interface ICustomerService
	{
		Task<CustomerDto> AddCustomer(CustomerDto customer);
		Task<string> DeleteCustomer(string id);
		Task<List<CustomerDto>> GetCustomerList();
		Task<CustomerDto> GetCustomer(string id);
	}
	public class CustomerService : ICustomerService
	{
		public async Task<CustomerDto> AddCustomer(CustomerDto customer)
		{
			var db = DBConnectionExtension.MongoDBConnection();
			var dbOrder = db.GetCollection<Customer>("customers");
			var address = new AdressDto()
			{
				AdressLine = customer.Adress.AdressLine,
				City = customer.Adress.City,
				CityCode = customer.Adress.CityCode,
				Country = customer.Adress.Country
			};

			var customer1 = new CustomerDto()
			{
				Email = customer.Email,
				Name = customer.Name,
				Adress = address
			};

			var response = JsonConvert.DeserializeObject<Customer>(JsonConvert.SerializeObject(customer1));
			if (response != null)
				await dbOrder.InsertOneAsync(response);

			return customer1;
		}

		public async Task<string> DeleteCustomer(string name)
		{
			var db = DBConnectionExtension.MongoDBConnection().GetCollection<Customer>("customers");
			await db.DeleteOneAsync(x => x.Name == name);
			return HttpStatusCode.Accepted.ToString();
		}

		public async Task<List<CustomerDto>> GetCustomerList()
		{
			var db = DBConnectionExtension.MongoDBConnection();
			var dbCustomer = db.GetCollection<Customer>("customers");
			var listCustomer = new List<CustomerDto>();

			var cus = await dbCustomer.Find(x => true).ToListAsync();

			if (dbCustomer != null)
				listCustomer = JsonConvert.DeserializeObject<List<CustomerDto>>(JsonConvert.SerializeObject(cus));

			if (listCustomer != null)
			{
				return listCustomer;
			}

			return new List<CustomerDto>();
		}

		public async Task<CustomerDto> GetCustomer(string id)
		{
			var db = DBConnectionExtension.MongoDBConnection();
			var dbCustomer = db.GetCollection<Customer>("customers");

			//var cus = await dbCustomer.Find(x => x.Id.ToString() == id).ToListAsync();

			var cust = JsonConvert.DeserializeObject<CustomerDto>(JsonConvert.SerializeObject(dbCustomer.Find(x => x.Id.ToString() == id).ToListAsync()));

			return cust;
		}
	}
}