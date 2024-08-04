using Newtonsoft.Json;

namespace Tesodev.Shared.Data.Dto
{
	public class ProductDto
	{
		[JsonProperty("imageUrl")]
		public string ImageUrl { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }

		public ProductDto()
		{

		}

		public ProductDto( string imageUrl, string name)
		{
			ImageUrl = imageUrl;
			Name = name;
		}
	}
}
