﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace descent_remote_final.Models
{
    public class OverlordRelicCard
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("location")]
        public string Location { get; set; }
    }
}
