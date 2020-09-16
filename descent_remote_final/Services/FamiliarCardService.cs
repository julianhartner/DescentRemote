using descent_remote_final.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace descent_remote_final.Services
{
    public class FamiliarCardService
    {
        private readonly IMongoCollection<FamiliarCard> familiarCards;

        public FamiliarCardService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("DescentRemoteDB"));
            IMongoDatabase database = client.GetDatabase("descent_remote");
            familiarCards = database.GetCollection<FamiliarCard>("familiar_cards");
        }

        public IList<FamiliarCard> Get()
        {
            return familiarCards.Find(card => true).ToList();
        }

        public FamiliarCard Get(string id)
        {
            return familiarCards.Find(card => card.Id == id).FirstOrDefault();
        }

        public FamiliarCard Create(FamiliarCard card)
        {
            familiarCards.InsertOne(card);
            return card;
        }

        public IEnumerable<FamiliarCard> CreateMultiple(IEnumerable<FamiliarCard> cards)
        {
            this.familiarCards.InsertMany(cards);
            return cards;
        }

        public void Update(string id, FamiliarCard cardIn)
        {
            familiarCards.ReplaceOne(card => card.Id == id, cardIn);
        }

        public void Remove(FamiliarCard cardIn)
        {
            familiarCards.DeleteOne(card => card.Id == cardIn.Id);
        }

        public void Remove(string id)
        {
            familiarCards.DeleteOne(card => card.Id == id);
        }
    }
}
