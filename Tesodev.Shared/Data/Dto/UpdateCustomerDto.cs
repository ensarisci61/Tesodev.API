namespace Tesodev.Shared.Data.Dto
{
	public class UpdateCustomerDto
	{
		public string Email { get; set; }
		public AdressDto Adress { get; set; }

		public UpdateCustomerDto()
		{

		}

		public UpdateCustomerDto(string email, AdressDto adress)
		{
			Email = email;
			Adress = adress;
		}
	}
}
