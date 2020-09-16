using descent_remote_final.Constants;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections;
using System.Collections.Generic;

namespace descent_remote_final.Models.Monsters
{
    public class Monster
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("location")]
        public string Location { get; set; }

        [BsonElement("biography")]
        public string Biography { get; set; }

        [BsonElement("attack_type")]
        public AttackType AttackType { get; set; }

        [BsonElement("two_player_minion")]
        public int TwoPlayerMinion { get; set; }

        [BsonElement("two_player_master")]
        public int TwoPlayerMaster { get; set; }

        [BsonElement("three_player_minion")]
        public int ThreePlayerMinion { get; set; }

        [BsonElement("three_player_master")]
        public int ThreePlayerMaster { get; set; }

        [BsonElement("four_player_minion")]
        public int FourPlayerMinion { get; set; }

        [BsonElement("four_player_master")]
        public int FourPlayerMaster { get; set; }

        [BsonElement("traits")]
        public IList<MonsterTrait> Traits { get; set; }

        [BsonElement("act1")]
        public ActMonster Act1 { get; set; }

        [BsonElement("act2")]
        public ActMonster Act2 { get; set; }
    }
}
