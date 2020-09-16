using descent_remote_final.Constants;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace descent_remote_final.Models.Lieutenants
{
    public class ActLieutenant
    {
        [BsonElement("might")]
        public int Might { get; set; }

        [BsonElement("knowledge")]
        public int Knowledge { get; set; }

        [BsonElement("willpower")]
        public int Willpower { get; set; }

        [BsonElement("awareness")]
        public int Awareness { get; set; }

        [BsonElement("attack_dice")]
        public IList<AttackDice> AttackDice { get; set; }

        [BsonElement("specials")]
        public IList<SpecialAttack> Specials { get; set; }

        [BsonElement("stats")]
        public IList<LieutenantStat> Stats { get; set; }
    }
}
