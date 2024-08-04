using MongoDB.Bson.Serialization.Attributes;
using Tesodev.Shared.Data.Attribute;
using Tesodev.Shared.Data.Entities;

namespace Tesodev.Shared.Data
{
    [BsonCollection("Customer")]
    [BsonIgnoreExtraElements]
    public class Customer : MongoEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Adress Adress { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Customer()
        {
            Adress = new Adress();
        }
    }
}
