using descent_remote_final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace descent_remote_final.ViewModels
{
    public class UserEditViewModel
    {
        public UserEditViewModel()
        {

        }

        public UserEditViewModel(User user, IList<ShopCard> shopCards, IList<SkillCard> skillCards, IList<ClassEquipmentCard> classEquipmentCards, IList<FamiliarCard> familiarCards)
        {
            if (user != null)
            {
                Id = user.Id;
                Name = user.Name;
            }
                

            if (user.Character != null)
                CharacterName = user.Character.Name;

            ShopCards = new List<CheckBoxClass>();
            SkillCards = new List<CheckBoxClass>();
            ClassEquipmentCards = new List<CheckBoxClass>();
            FamiliarCards = new List<CheckBoxClass>();

            foreach (var shopCard in shopCards)
            {
                var checkBox = new CheckBoxClass { DisplayName = shopCard.Name };

                if (user.HasShopCard(shopCard))
                    checkBox.Selected = true;

                ShopCards.Add(checkBox);
            }

            foreach (var skillCard in skillCards)
            {
                var checkBox = new CheckBoxClass { DisplayName = skillCard.Name };

                if (user.HasSkillCard(skillCard))
                    checkBox.Selected = true;

                SkillCards.Add(checkBox);
            }

            foreach (var classEquipmentCard in classEquipmentCards)
            {
                var checkBox = new CheckBoxClass { DisplayName = classEquipmentCard.Name };

                if (user.HasClassEquipmentCard(classEquipmentCard))
                    checkBox.Selected = true;

                ClassEquipmentCards.Add(checkBox);
            }

            foreach (var familiarCard in familiarCards)
            {
                var checkBox = new CheckBoxClass { DisplayName = familiarCard.Name };

                if (user.HasFamiliarCard(familiarCard))
                    checkBox.Selected = true;

                FamiliarCards.Add(checkBox);
            }
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string CharacterName { get; set; }
        public IList<CheckBoxClass> ShopCards { get; set; }
        public IList<CheckBoxClass> SkillCards { get; set; }
        public IList<CheckBoxClass> ClassEquipmentCards { get; set; }
        public IList<CheckBoxClass> FamiliarCards { get; set; }

        public bool MyProperty { get; set; }

        public class CheckBoxClass
        {
            public string DisplayName { get; set; }

            public bool Selected { get; set; }
        }
    }
}
