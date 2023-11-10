using MongoDB.Bson.Serialization.Attributes;

namespace DesafioBackend.Models
{
    public class Address
    {
        [BsonElement("Street")]
        public string Street { get; set; } = null!;

        [BsonElement("Number")]
        public int Number { get; set; }

        [BsonElement("City")]
        public string City { get; set; } = null!;

        [BsonElement("State")]
        public string State { get; set; } = null!;
    }
}
