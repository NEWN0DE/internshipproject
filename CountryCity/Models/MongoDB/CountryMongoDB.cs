using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CountryCity.Models.MongoDB
{
    public class CountryMongoDB
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string CountryName { get; set; } = null!;

        public string Capital { get; set; } = null!;

        public int Population { get; set; }



    }
}
