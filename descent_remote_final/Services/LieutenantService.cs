using descent_remote_final.Models.Lieutenants;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace descent_remote_final.Services
{
    public class LieutenantService
    {
        private readonly IMongoCollection<Lieutenant> lieutenants;

        public LieutenantService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("DescentRemoteDB"));
            IMongoDatabase database = client.GetDatabase("descent_remote");
            lieutenants = database.GetCollection<Lieutenant>("lieutenants");
        }

        public IList<Lieutenant> Get()
        {
            return lieutenants.Find(card => true).ToList();
        }

        public Lieutenant Get(string id)
        {
            return lieutenants.Find(card => card.Id == id).FirstOrDefault();
        }

        public Lieutenant Create(Lieutenant lieutenant)
        {
            lieutenants.InsertOne(lieutenant);
            return lieutenant;
        }

        public IEnumerable<Lieutenant> CreateMultiple(IEnumerable<Lieutenant> lieutenants)
        {
            this.lieutenants.InsertMany(lieutenants);
            return lieutenants;
        }

        public void Update(string id, Lieutenant lieutenantIn)
        {
            lieutenants.ReplaceOne(lieutenant => lieutenant.Id == id, lieutenantIn);
        }

        public void Remove(Lieutenant lieutenantIn)
        {
            lieutenants.DeleteOne(lieutenant => lieutenant.Id == lieutenantIn.Id);
        }

        public void Remove(string id)
        {
            lieutenants.DeleteOne(lieutenant => lieutenant.Id == id);
        }
    }
}
