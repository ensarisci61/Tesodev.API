using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Tesodev.Shared.Data.Entities
{
	public interface IMongoEntity
	{
		[BsonId]
		[BsonRepresentation(BsonType.String)]
		ObjectId Id { get; set; }
		DateTime CreatedAt { get; set; }
	}

	public class MongoEntity
	{
		protected MongoEntity()
		{
			Id = new ObjectId();
			CreatedAt = DateTime.Now;
		}
		public ObjectId Id { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
