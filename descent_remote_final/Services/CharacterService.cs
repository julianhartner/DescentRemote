using descent_remote_final.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace descent_remote_final.Services
{
    public class CharacterService
    {
        private readonly IMongoCollection<Character> characters;

        public CharacterService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("DescentRemoteDB"));
            IMongoDatabase database = client.GetDatabase("descent_remote");
            characters = database.GetCollection<Character>("characters");
        }

        public List<Character> Get()
        {
            return characters.Find(character => true).ToList();
        }

        public Character Get(string id)
        {
            return characters.Find(character => character.Id == id).FirstOrDefault();
        }

        public Character GetByName(string name)
        {
            return characters.Find(character => character.Name == name).FirstOrDefault();
        }

        public Character Create(Character character)
        {
            characters.InsertOne(character);
            return character;
        }

        public IEnumerable<Character> CreateMultiple(IEnumerable<Character> characters)
        {
            this.characters.InsertMany(characters);
            return characters;
        }

        public void Update(string id, Character characterIn)
        {
            characters.ReplaceOne(character => character.Id == id, characterIn);
        }

        public void Remove(Character characterIn)
        {
            characters.DeleteOne(character => character.Id == characterIn.Id);
        }

        public void Remove(string id)
        {
            characters.DeleteOne(character => character.Id == id);
        }
    }
}
