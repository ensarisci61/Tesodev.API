using Newtonsoft.Json;
using Tesodev.Shared.Data.Entities;

namespace Tesodev.Shared.Data.Dto
{
	public class CustomerDto 
	{
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("eMail")]
		public string Email { get; set; }
		[JsonProperty("adress")]
		public AdressDto Adress { get; set; }

		public CustomerDto()
		{
			
		}

		public CustomerDto(string name, string email, AdressDto adress)
		{
			Name = name;
			Email = email;
			Adress.AdressLine = adress.AdressLine;
			Adress.City = adress.City;
			Adress.Country = adress.Country;
			Adress.CityCode = adress.CityCode;
		}
	}
}
