using descent_remote_final.Constants;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace descent_remote_final.Models
{
    public class SkillCard
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("location")]
        public string Location { get; set; }

        [BsonElement("fatigue_cost")]
        public int FatigueCost { get; set; }

        [BsonElement("skillpoints_needed")]
        public int SkillpointsNeeded { get; set; }

        [BsonElement("class_type")]
        public ClassType Classtype { get; set; }

        [BsonIgnore]
        public bool IsExhausted { get; set; }
    }
}
