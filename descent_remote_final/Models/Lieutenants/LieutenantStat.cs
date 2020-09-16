using descent_remote_final.Constants;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace descent_remote_final.Models.Lieutenants
{
    public class LieutenantStat
    {
        [BsonElement("number_of_heroes")]
        public int NumberOfHeroes { get; set; }

        [BsonElement("speed")]
        public int Speed { get; set; }

        [BsonElement("health")]
        public int Health { get; set; }

        [BsonElement("defense_dice")]
        public IList<DefenseDie> DefenseDice { get; set; }
    }
}
