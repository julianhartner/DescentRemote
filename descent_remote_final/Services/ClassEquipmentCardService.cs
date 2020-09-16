using descent_remote_final.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace descent_remote_final.Services
{
    public class ClassEquipmentCardService
    {
        private readonly IMongoCollection<ClassEquipmentCard> classEquipmentCards;

        public ClassEquipmentCardService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("DescentRemoteDB"));
            IMongoDatabase database = client.GetDatabase("descent_remote");
            classEquipmentCards = database.GetCollection<ClassEquipmentCard>("class_equipment_cards");
        }

        public IList<ClassEquipmentCard> Get()
        {
            return classEquipmentCards.Find(card => true).ToList();
        }

        public ClassEquipmentCard Get(string id)
        {
            return classEquipmentCards.Find(card => card.Id == id).FirstOrDefault();
        }

        public ClassEquipmentCard Create(ClassEquipmentCard card)
        {
            classEquipmentCards.InsertOne(card);
            return card;
        }

        public IEnumerable<ClassEquipmentCard> CreateMultiple(IEnumerable<ClassEquipmentCard> cards)
        {
            this.classEquipmentCards.InsertMany(cards);
            return cards;
        }

        public void Update(string id, ClassEquipmentCard cardIn)
        {
            classEquipmentCards.ReplaceOne(card => card.Id == id, cardIn);
        }

        public void Remove(ClassEquipmentCard cardIn)
        {
            classEquipmentCards.DeleteOne(card => card.Id == cardIn.Id);
        }

        public void Remove(string id)
        {
            classEquipmentCards.DeleteOne(card => card.Id == id);
        }
    }
}
