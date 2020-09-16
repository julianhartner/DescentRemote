using descent_remote_final.Constants;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace descent_remote_final.Models.Lieutenants
{
    public class Lieutenant
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

        [BsonElement("act1")]
        public ActLieutenant Act1 { get; set; }

        [BsonElement("act2")]
        public ActLieutenant Act2 { get; set; }
    }
}
