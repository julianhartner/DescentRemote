using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace descent_remote_final.Models
{
    public class FamiliarCard
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        [Required]
        public string Name { get; set; }

        [BsonElement("location")]
        public string Location { get; set; }

        [BsonElement("speed")]
        public int Speed { get; set; }

        [BsonElement("health")]
        public int Health { get; set; }

        [BsonElement("current_health")]
        public int CurrentHealth { get; set; }
    }
}
