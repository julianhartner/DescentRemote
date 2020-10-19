using System.Collections.Generic;
using descent_remote_final.Models;
using descent_remote_final.Models.Lieutenants;
using descent_remote_final.Models.Monsters;

namespace descent_remote_final.Util
{
    public static class GameHandler
    {
        public static IList<User> Users { get; set; }

        public static IList<Monster> Monsters { get; set; }

        public static IList<Lieutenant> Lieutenants { get; set; }
    }
}