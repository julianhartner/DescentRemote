using descent_remote_final.Models;
using descent_remote_final.Models.Lieutenants;
using descent_remote_final.Models.Monsters;
using System.Collections.Generic;

namespace descent_remote_final.Services
{
    public class GameHandler
    {
        public GameHandler()
        {
            Users = new List<User>();
            Monsters = new List<Monster>();
            Lieutenants = new List<Lieutenant>();
        }

        public IList<User> Users { get; set; }

        public IList<Monster> Monsters { get; set; }

        public IList<Lieutenant> Lieutenants { get; set; }
    }
}
