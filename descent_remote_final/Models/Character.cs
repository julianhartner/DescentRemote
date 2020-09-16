using descent_remote_final.Constants;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace descent_remote_final.Models
{
    public class Character
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("imageLocation")]
        public string ImageLocation { get; set; }

        [BsonElement("archetype")]
        public Archetype Archetype { get; set; }

        [BsonElement("speed")]
        public int Speed { get; set; }

        [BsonElement("health")]
        public int Health { get; set; }

        [BsonIgnore]
        public int CurrentHealth { get; set; }

        [BsonElement("stamina")]
        public int Stamina { get; set; }

        [BsonIgnore]
        public int CurrentStamina { get; set; }

        [BsonElement("defense_dice")]
        public IList<DefenseDie> DefenseDice { get; set; }

        [BsonElement("might")]
        public int Might { get; set; }

        [BsonElement("knowledge")]
        public int Knowledge { get; set; }

        [BsonElement("willpower")]
        public int Willpower { get; set; }

        [BsonElement("awareness")]
        public int Awareness { get; set; }

        [BsonElement("heroAbility")]
        public string HeroAbility { get; set; }

        [BsonElement("heroicFeat")]
        public string HeroicFeat { get; set; }

        [BsonIgnore]
        public bool HeroicFeatUsed { get; set; }
    }
}
