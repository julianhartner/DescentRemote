using descent_remote_final.Constants;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace descent_remote_final.Models.Monsters
{
    public class ActMonster
    {
        [BsonElement("speed_minion")]
        public int SpeedMinion { get; set; }

        [BsonElement("health_minion")]
        public int HealthMinion { get; set; }

        [BsonElement("defense_dice_minion")]
        public IList<DefenseDie> DefenseDiceMinion { get; set; }

        [BsonElement("attack_dice_minion")]
        public IList<AttackDice> AttackDiceMinion { get; set; }

        [BsonElement("speed_master")]
        public int SpeedMaster { get; set; }

        [BsonElement("health_master")]
        public int HealthMaster { get; set; }

        [BsonElement("defense_dice_master")]
        public IList<DefenseDie> DefenseDiceMaster { get; set; }

        [BsonElement("attack_dice_master")]
        public IList<AttackDice> AttackDiceMaster { get; set; }

        [BsonElement("specials_minion")]
        public IList<SpecialAttack> SpecialsMinion { get; set; }

        [BsonElement("specials_master")]
        public IList<SpecialAttack> SpecialsMaster { get; set; }
    }
}
