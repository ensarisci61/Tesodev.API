using MongoDB.Bson.Serialization.Attributes;
using Tesodev.Shared.Data.Attribute;
using Tesodev.Shared.Data.Entities;

namespace Tesodev.Shared.Data
{
    [BsonCollection("Order")]
    [BsonIgnoreExtraElements]
    public class Order : MongoEntity
    {
        public string CustomerId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
        public Adress Adress { get; set; }
        public Product Product { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Order()
        {
            Adress = new Adress();
            Product = new Product();
        }
    }
}
