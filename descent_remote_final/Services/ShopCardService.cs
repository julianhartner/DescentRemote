using descent_remote_final.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace descent_remote_final.Services
{
    public class ShopCardService
    {
        private readonly IMongoCollection<ShopCard> shopCards;

        public ShopCardService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("DescentRemoteDB"));
            IMongoDatabase database = client.GetDatabase("descent_remote");
            shopCards = database.GetCollection<ShopCard>("shop_cards");
        }

        public IList<ShopCard> Get()
        {
            return shopCards.Find(card => true).ToList();
        }

        public ShopCard Get(string id)
        {
            return shopCards.Find(card => card.Id == id).FirstOrDefault();
        }

        public ShopCard Create(ShopCard card)
        {
            shopCards.InsertOne(card);
            return card;
        }

        public IEnumerable<ShopCard> CreateMultiple(IEnumerable<ShopCard> cards)
        {
            this.shopCards.InsertMany(cards);
            return cards;
        }

        public void Update(string id, ShopCard cardIn)
        {
            shopCards.ReplaceOne(card => card.Id == id, cardIn);
        }

        public void Remove(ShopCard cardIn)
        {
            shopCards.DeleteOne(card => card.Id == cardIn.Id);
        }

        public void Remove(string id)
        {
            shopCards.DeleteOne(card => card.Id == id);
        }
    }
}
