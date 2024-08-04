using System.Net;
using MongoDB.Driver;
using Newtonsoft.Json;
using Tesodev.Shared.Data.Dto;
using Tesodev.Shared.Data.Extensions;

namespace Tesodev.Shared.Data.Service.ProductService
{
	public interface IProductService
	{
		Task<ProductDto> AddProduct(ProductDto product);
		Task<string> DeleteProduct(string id);
		Task<List<ProductDto>> GetProductList();
		Task<ProductDto> GetProductById(string id);
	}
	public class ProductService : IProductService
	{
		public async Task<ProductDto> AddProduct(ProductDto product)
		{
			var db = DBConnectionExtension.MongoDBConnection();
			var dbProduct = db.GetCollection<Product>("Product");

			var product1 = new ProductDto()
			{
				Name = product.Name,
				ImageUrl = product.ImageUrl
			};

			var response = JsonConvert.DeserializeObject<Product>(JsonConvert.SerializeObject(product1));
			if (response != null)
				await dbProduct.InsertOneAsync(response);

			return product1;
		}

		public async Task<string> DeleteProduct(string name)
		{
			var db = DBConnectionExtension.MongoDBConnection().GetCollection<Product>("Product");

			await db.DeleteOneAsync(x => x.Name == name);
			return HttpStatusCode.Accepted.ToString();
		}

		public async Task<List<ProductDto>> GetProductList()
		{
			var db = DBConnectionExtension.MongoDBConnection();
			var dbProduct = db.GetCollection<Product>("Product");
			var listProduct = new List<ProductDto>();

			var cus = await dbProduct.Find(x => true).ToListAsync();

			if (dbProduct != null)
				listProduct = JsonConvert.DeserializeObject<List<ProductDto>>(JsonConvert.SerializeObject(cus));

			if (listProduct != null)
			{
				return listProduct;
			}

			return new List<ProductDto>();


		}

		public async Task<ProductDto> GetProductById(string id)
		{
			var db = DBConnectionExtension.MongoDBConnection().GetCollection<Product>("Product");

			var cust = JsonConvert.DeserializeObject<ProductDto>(JsonConvert.SerializeObject(db.Find(x => x.Id.ToString() == id).ToListAsync()));

			return cust;
		}
	}
}
