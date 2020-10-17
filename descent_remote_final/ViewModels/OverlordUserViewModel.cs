using descent_remote_final.Models;
using descent_remote_final.Models.Lieutenants;
using descent_remote_final.Models.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace descent_remote_final.ViewModels
{
    public class OverlordUserViewModel
    {
        public OverlordUserViewModel(User user)
        {
            Id = user.Id;
            Name = user.Name;
            OverlordCards = user.OverlordCards;
            RemainingOverlordCards = user.RemainingOverlordCards;
            HandOverlordCards = user.HandOverlordCards;
            DiscardedOverlordCards = user.DiscardedOverlordCards;
            Monsters = user.Monsters;
            Lieutenants = user.Lieutenants;
            OverlordRelics = user.OverlordRelics;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public IList<OverlordCard> OverlordCards { get; set; }
        public IList<OverlordCard> RemainingOverlordCards { get; set; }
        public IList<OverlordCard> HandOverlordCards { get; set; }
        public IList<OverlordCard> DiscardedOverlordCards { get; set; }
        public IList<Monster> Monsters { get; set; }
        public IList<Lieutenant> Lieutenants { get; set; }
        public IList<OverlordRelicCard> OverlordRelics { get; set; }
    }
}
