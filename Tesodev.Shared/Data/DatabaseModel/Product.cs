using MongoDB.Bson.Serialization.Attributes;
using Tesodev.Shared.Data.Attribute;
using Tesodev.Shared.Data.Entities;

namespace Tesodev.Shared.Data
{
	[BsonCollection("Product")]
    [BsonIgnoreExtraElements]
    public class Product : MongoEntity
    {
		public string ImageUrl { get; set; }
		public string Name { get; set; }

        public Product()
        {

        }
    }
}
