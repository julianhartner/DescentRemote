using descent_remote_final.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace descent_remote_final.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> users;

        public UserService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("DescentRemoteDB"));
            IMongoDatabase database = client.GetDatabase("descent_remote");
            users = database.GetCollection<User>("users");
        }

        public List<User> Get()
        {
            return users.Find(user => true).ToList();
        }

        public User Get(string id)
        {
            return users.Find(user => user.Id == id).FirstOrDefault();
        }

        public User Create(User user)
        {
            users.InsertOne(user);
            return user;
        }

        public IEnumerable<User> CreateMultiple(IEnumerable<User> users)
        {
            this.users.InsertMany(users);
            return users;
        }

        public void Update(string id, User userIn)
        {
            users.ReplaceOne(user => user.Id == id, userIn);
        }

        public void Remove(User userIn)
        {
            users.DeleteOne(user => user.Id == userIn.Id);
        }

        public void Remove(string id)
        {
            users.DeleteOne(user => user.Id == id);
        }
    }
}
