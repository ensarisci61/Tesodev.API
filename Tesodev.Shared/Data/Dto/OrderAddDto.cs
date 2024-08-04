using Newtonsoft.Json;

namespace Tesodev.Shared.Data.Dto
{
	public class OrderAddDto
	{
		[JsonProperty("quantity")] public int Quantity { get; set; }
		[JsonProperty("price")] public int Price { get; set; }

		public OrderAddDto()
		{

		}

		public OrderAddDto(int quantity, int price)
		{
			Quantity = quantity;
			Price = price;
		}
	}
}
