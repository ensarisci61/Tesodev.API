using Newtonsoft.Json;

namespace Tesodev.Shared.Data.Dto
{
	public class AdressDto
	{
		[JsonProperty("adressLine")]
		public string AdressLine { get; set; }
		[JsonProperty("city")]
		public string City { get; set; }
		[JsonProperty("country")]
		public string Country { get; set; }
		[JsonProperty("cityCode")]
		public int CityCode { get; set; }

		public AdressDto()
		{

		}

		public AdressDto(string adressLine, string city, string country, int cityCode)
		{
			AdressLine = adressLine;
			City = city;
			Country = country;
			CityCode = cityCode;
		}
	}
}
