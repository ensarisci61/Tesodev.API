using MongoDB.Bson.Serialization.Attributes;
using Tesodev.Shared.Data.Attribute;

namespace Tesodev.Shared.Data
{
    [BsonCollection("Adress")]
    [BsonIgnoreExtraElements]
    public class Adress
    {
        public string AdressLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int CityCode { get; set; }

        public Adress()
        {

        }
    }
}
