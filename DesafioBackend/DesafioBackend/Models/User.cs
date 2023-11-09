using MongoDB.Bson.Serialization.Attributes;

namespace DesafioBackend.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; } = null!;
        public string Age { get; set; } = null!;
    }
}
