using descent_remote_final.Models;
using System.Collections.Generic;
using System.Linq;

namespace descent_remote_final.ViewModels
{
    public class DashboardUserViewModel
    {
        public DashboardUserViewModel(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Character = user.Character;
            ShopCards = user.ShopCards.Select(card => new ShopCardViewModel(card)).ToList();
            SkillCards = user.SkillCards.Select(card => new SkillCardViewModel(card)).ToList();
            ClassEquipmentCards = user.ClassEquipmentCards.Select(card => new ClassEquipmentCardViewModel(card)).ToList();
            FamiliarCards = user.FamiliarCards.Select(card => new FamiliarCardViewModel(card)).ToList();
        }

        public string Id { get; set; }
        public string ExhaustButtonId => Id + "_exhaust";
        public string RefreshButtonId => Id + "_refresh";
        public string EquipButtonId => Id + "_equip";
        public string UnequipButtonId => Id + "_unequip";
        public string Name { get; set; }
        public Character Character { get; set; }
        public IList<ShopCardViewModel> ShopCards { get; set; }
        public IList<SkillCardViewModel> SkillCards { get; set; }
        public IList<ClassEquipmentCardViewModel> ClassEquipmentCards { get; set; }
        public IList<FamiliarCardViewModel> FamiliarCards { get; set; }
    }
}
