using descent_remote_final.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace descent_remote_final.Services
{
    public class SkillCardService
    {
        private readonly IMongoCollection<SkillCard> skillCards;

        public SkillCardService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("DescentRemoteDB"));
            IMongoDatabase database = client.GetDatabase("descent_remote");
            skillCards = database.GetCollection<SkillCard>("skill_cards");
        }

        public IList<SkillCard> Get()
        {
            return skillCards.Find(card => true).ToList();
        }

        public SkillCard Get(string id)
        {
            return skillCards.Find(card => card.Id == id).FirstOrDefault();
        }

        public SkillCard Create(SkillCard card)
        {
            skillCards.InsertOne(card);
            return card;
        }

        public IEnumerable<SkillCard> CreateMultiple(IEnumerable<SkillCard> cards)
        {
            this.skillCards.InsertMany(cards);
            return cards;
        }

        public void Update(string id, SkillCard cardIn)
        {
            skillCards.ReplaceOne(card => card.Id == id, cardIn);
        }

        public void Remove(SkillCard cardIn)
        {
            skillCards.DeleteOne(card => card.Id == cardIn.Id);
        }

        public void Remove(string id)
        {
            skillCards.DeleteOne(card => card.Id == id);
        }
    }
}
