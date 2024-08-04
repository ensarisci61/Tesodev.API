using Newtonsoft.Json;

namespace Tesodev.Shared.Data.Dto
{
	public class OrderDto
	{
		[JsonProperty("customerId")] public string CustomerId { get; set; }
		[JsonProperty("quantity")] public int Quantity { get; set; }
		[JsonProperty("price")] public int Price { get; set; }
		[JsonProperty("status")] public string Status { get; set; }
		[JsonProperty("Adress")] public Adress Adress { get; set; }
		[JsonProperty("Product")] public Product Product { get; set; }

		public OrderDto()
		{

		}

		public OrderDto(string customerId, int quantity, int price, string status, Adress adress,
			Product product)
		{
			CustomerId = customerId;
			Quantity = quantity;
			Price = price;
			Status = status;
			Adress = adress;
			Product = product;
		}
	}
}
