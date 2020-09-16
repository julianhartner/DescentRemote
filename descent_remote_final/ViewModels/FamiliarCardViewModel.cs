using descent_remote_final.Models;

namespace descent_remote_final.ViewModels
{
    public class FamiliarCardViewModel
    {
        public FamiliarCardViewModel(FamiliarCard card)
        {
            Id = card.Id;
            Name = card.Name;
            Location = card.Location;
            Health = card.Health;
            CurrentHealth = card.CurrentHealth;
        }

        public string Id { get; set; }
        public string AddHealthId => Id + "_addhealth";
        public string RemoveHealthId => Id + "_removehealth";
        public string ReviveId => Id + "_revive";
        public string HealthId => Id + "_health";
        public string CurrentHealthId => Id + "_currenthealth";
        public string Name { get; set; }
        public string Location { get; set; }
        public int Health { get; set; }
        public int CurrentHealth { get; set; }
    }
}
