namespace Tesodev.Shared.Data.Dto
{
	public class UpdateOrderDto
	{
		public int Quantity { get; set; }
		public int Price { get; set; }
		public AdressDto Adress { get; set; }
	}
}
