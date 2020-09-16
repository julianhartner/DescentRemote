using descent_remote_final.Models.Monsters;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace descent_remote_final.Services
{
    public class MonsterService
    {
        private readonly IMongoCollection<Monster> monsters;

        public MonsterService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("DescentRemoteDB"));
            IMongoDatabase database = client.GetDatabase("descent_remote");
            monsters = database.GetCollection<Monster>("monsters");
        }

        public IList<Monster> Get()
        {
            return monsters.Find(card => true).ToList();
        }

        public Monster Get(string id)
        {
            return monsters.Find(card => card.Id == id).FirstOrDefault();
        }

        public Monster Create(Monster monster)
        {
            monsters.InsertOne(monster);
            return monster;
        }

        public IEnumerable<Monster> CreateMultiple(IEnumerable<Monster> monster)
        {
            this.monsters.InsertMany(monster);
            return monster;
        }

        public void Update(string id, Monster monsterIn)
        {
            monsters.ReplaceOne(monster => monster.Id == id, monsterIn);
        }

        public void Remove(Monster monsterIn)
        {
            monsters.DeleteOne(monster => monster.Id == monsterIn.Id);
        }

        public void Remove(string id)
        {
            monsters.DeleteOne(monster => monster.Id == id);
        }
    }
}
