using descent_remote_final.Models;

namespace descent_remote_final.ViewModels
{
    public class SkillCardViewModel
    {
        public SkillCardViewModel(SkillCard card)
        {
            Id = card.Id;
            Name = card.Name;
            Location = card.Location;
            FatigueCost = card.FatigueCost;
            SkillpointsNeeded = card.SkillpointsNeeded;
            Classtype = card.Classtype.ToString();
            IsExhausted = card.IsExhausted;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int FatigueCost { get; set; }
        public int SkillpointsNeeded { get; set; }
        public string Classtype { get; set; }
        public string ExhaustButtonId => Id + "_exhaust";
        public string RefreshButtonId => Id + "_refresh";
        public string EquipButtonId => Id + "_equip";
        public string UnequipButtonId => Id + "_unequip";
        public bool IsExhausted { get; set; }
    }
}
