using descent_remote_final.Models;

namespace descent_remote_final.ViewModels
{
    public class ClassEquipmentCardViewModel
    {
        public ClassEquipmentCardViewModel(ClassEquipmentCard card)
        {
            Id = card.Id;
            Name = card.Name;
            Location = card.Location;
            EquipmentType = card.EquipmentType.ToString();
            IsEquipped = card.IsEquipped;
            IsExhausted = card.IsExhausted;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string EquipmentType { get; set; }
        public string ExhaustButtonId => Id + "_exhaust";
        public string RefreshButtonId => Id + "_refresh";
        public string EquipButtonId => Id + "_equip";
        public string UnequipButtonId => Id + "_unequip";
        public bool IsEquipped { get; set; }
        public bool IsExhausted { get; set; }
    }
}
