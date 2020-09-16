using descent_remote_final.Constants;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace descent_remote_final.Models
{
    public class ClassEquipmentCard
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("location")]
        public string Location { get; set; }

        [BsonElement("equipment_type")]
        public EquipmentType EquipmentType { get; set; }

        [BsonIgnore]
        public bool IsEquipped { get; set; }

        [BsonIgnore]
        public bool IsExhausted { get; set; }
    }
}
