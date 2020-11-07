using System.Linq;
using descent_remote_final.Services;
using descent_remote_final.Util;
using descent_remote_final.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace descent_remote_final.Controllers
{
    [EnableCors("ApiPolicy")]
    public class ApiController : Controller
    {
        public ApiController()
        {
        }

        // GET: Api/AddHealth
        public ActionResult AddHealth(string id)
        {
            var user = GameHandler.Users.FirstOrDefault(u => u.Id == id);

            if (user == null && user.Character == null)
                return null;

            int newHealth;
            if (user.Character.CurrentHealth >= user.Character.Health)
            {
                newHealth = user.Character.Health;
            }
            else
            {
                newHealth = user.Character.CurrentHealth + 1;
            }

            user.Character.CurrentHealth = newHealth;
            return Json(newHealth);
        }

        // GET: Api/RemoveHealth
        public ActionResult RemoveHealth(string id)
        {
            var user = GameHandler.Users.FirstOrDefault(u => u.Id == id);

            if (user.Character == null)
                return null;

            int newHealth;
            if (user.Character.CurrentHealth <= 0)
            {
                newHealth = 0;
            }
            else
            {
                newHealth = user.Character.CurrentHealth - 1;
            }

            user.Character.CurrentHealth = newHealth;
            return Json(newHealth);
        }

        // GET: Api/AddStamina
        public ActionResult AddStamina(string id)
        {
            var user = GameHandler.Users.FirstOrDefault(u => u.Id == id);

            if (user.Character == null)
                return null;

            int newStamina;
            if (user.Character.CurrentStamina >= user.Character.Stamina)
            {
                newStamina = user.Character.Stamina;
            }
            else
            {
                newStamina = user.Character.CurrentStamina + 1;
            }

            user.Character.CurrentStamina = newStamina;
            return Json(newStamina);
        }

        // GET: Api/RemoveStamina
        public ActionResult RemoveStamina(string id)
        {
            var user = GameHandler.Users.FirstOrDefault(u => u.Id == id);

            if (user.Character == null)
                return null;

            int newStamina;
            if (user.Character.CurrentStamina <= 0)
            {
                newStamina = 0;
            }
            else
            {
                newStamina = user.Character.CurrentStamina - 1;
            }

            user.Character.CurrentStamina = newStamina;
            return Json(newStamina);
        }

        // GET: Api/AddFamiliarHealth
        public ActionResult AddFamiliarHealth(string userId, string familiarId)
        {
            var user = GameHandler.Users.FirstOrDefault(u => u.Id == userId);

            if (user.Character == null)
                return null;

            var familiarCard = user.FamiliarCards.FirstOrDefault(card => card.Id == familiarId);

            if (familiarCard.CurrentHealth <= 0)
            {
                return Json(0);
            }
            
            int newHealth;
            if (familiarCard.CurrentHealth >= familiarCard.Health)
            {
                newHealth = familiarCard.Health;
            }
            else
            {
                newHealth = familiarCard.CurrentHealth + 1;
            }

            familiarCard.CurrentHealth = newHealth;
            return Json(newHealth);
        }

        // GET: Api/RemoveFamiliarHealth
        public ActionResult RemoveFamiliarHealth(string userId, string familiarId)
        {
            var user = GameHandler.Users.FirstOrDefault(u => u.Id == userId);

            if (user.Character == null)
                return null;

            var familiarCard = user.FamiliarCards.FirstOrDefault(card => card.Id == familiarId);

            int newHealth;
            if (familiarCard.CurrentHealth <= 0)
            {
                newHealth = 0;
            }
            else
            {
                newHealth = familiarCard.CurrentHealth - 1;
            }

            familiarCard.CurrentHealth = newHealth;
            return Json(newHealth);
        }

        // GET: Api/RemoveFamiliarHealth
        public ActionResult ReviveFamiliar(string userId, string familiarId)
        {
            var user = GameHandler.Users.FirstOrDefault(u => u.Id == userId);

            if (user.Character == null)
                return null;

            var familiarCard = user.FamiliarCards.FirstOrDefault(card => card.Id == familiarId);

            if (familiarCard.CurrentHealth <= 0)
                familiarCard.CurrentHealth = familiarCard.Health;

            return Json(familiarCard.CurrentHealth);
        }

        public ActionResult ExhaustHeroicFeat(string userId)
        {
            var user = GameHandler.Users.FirstOrDefault(u => u.Id == userId);

            if (user.Character == null)
                return Json(false);

            if (user.Character.HeroicFeatUsed)
                return Json(false);

            user.Character.HeroicFeatUsed = true;
            return Json(true);
        }

        public ActionResult ExhaustCard(string userId, string cardId)
        {
            var user = GameHandler.Users.FirstOrDefault(u => u.Id == userId);

            var classEquipcard = user.ClassEquipmentCards.FirstOrDefault(u => u.Id == cardId);
            if (classEquipcard != null)
                if (!classEquipcard.IsExhausted)
                {
                    classEquipcard.IsExhausted = true;
                    return Json(true);
                }

            var shopCard = user.ShopCards.FirstOrDefault(u => u.Id == cardId);
            if (shopCard != null)
                if (!shopCard.IsExhausted)
                {
                    shopCard.IsExhausted = true;
                    return Json(true);
                }

            var skillCard = user.SkillCards.FirstOrDefault(u => u.Id == cardId);
            if (skillCard != null)
                if (!skillCard.IsExhausted)
                {
                    skillCard.IsExhausted = true;
                    return Json(true);
                }

            return Json(false);
        }

        public ActionResult RefreshCard(string userId, string cardId)
        {
            var user = GameHandler.Users.FirstOrDefault(u => u.Id == userId);

            var classEquipcard = user.ClassEquipmentCards.FirstOrDefault(u => u.Id == cardId);
            if (classEquipcard != null)
                if (classEquipcard.IsExhausted)
                {
                    classEquipcard.IsExhausted = false;
                    return Json(true);
                }

            var shopCard = user.ShopCards.FirstOrDefault(u => u.Id == cardId);
            if (shopCard != null)
                if (shopCard.IsExhausted)
                {
                    shopCard.IsExhausted = false;
                    return Json(true);
                }

            var skillCard = user.SkillCards.FirstOrDefault(u => u.Id == cardId);
            if (skillCard != null)
                if (skillCard.IsExhausted)
                {
                    skillCard.IsExhausted = false;
                    return Json(true);
                }

            return Json(false);
        }

        public ActionResult EquipCard(string userId, string cardId)
        {
            var user = GameHandler.Users.FirstOrDefault(u => u.Id == userId);

            var classEquipcard = user.ClassEquipmentCards.FirstOrDefault(u => u.Id == cardId);
            if (classEquipcard != null)
                if (!classEquipcard.IsEquipped)
                {
                    classEquipcard.IsEquipped = true;
                    return Json(true);
                }

            var shopCard = user.ShopCards.FirstOrDefault(u => u.Id == cardId);
            if (shopCard != null)
                if (!shopCard.IsEquipped)
                {
                    shopCard.IsEquipped = true;
                    return Json(true);
                }

            return Json(false);
        }

        public ActionResult UnequipCard(string userId, string cardId)
        {
            var user = GameHandler.Users.FirstOrDefault(u => u.Id == userId);

            var classEquipcard = user.ClassEquipmentCards.FirstOrDefault(u => u.Id == cardId);
            if (classEquipcard != null)
                if (classEquipcard.IsEquipped)
                {
                    classEquipcard.IsEquipped = false;
                    return Json(true);
                }

            var shopCard = user.ShopCards.FirstOrDefault(u => u.Id == cardId);
            if (shopCard != null)
                if (shopCard.IsEquipped)
                {
                    shopCard.IsEquipped = false;
                    return Json(true);
                }

            return Json(false);
        }

        public ActionResult Reset(string userId)
        {
            var user = GameHandler.Users.FirstOrDefault(u => u.Id == userId);

            user.Character.HeroicFeatUsed = false;
            return Json(true);
        }

        public ActionResult ResetGame()
        {
            var users = GameHandler.Users;

            if (users == null)
                return Json(false);

            foreach (var user in users)
            {
                if (user.Character != null)
                {
                    user.Character.CurrentHealth = user.Character.Health;
                    user.Character.CurrentStamina = user.Character.Stamina;
                    user.Character.HeroicFeatUsed = false;
                }

                if (user.FamiliarCards.Any())
                    foreach (var card in user.FamiliarCards)
                        card.CurrentHealth = 0;
            }

            return Json(true);
        }

        public ActionResult GetLieutenants()
        {
            return Json(GameHandler.Lieutenants);
        }

        public ActionResult GetMonsters()
        {
            return Json(GameHandler.Monsters);
        }

        public ActionResult GetUsers()
        {
            return Json(GameHandler.Users.Select(u => u.Name).ToArray());
        }

        public ActionResult AddLieutenant(string userId, string lieutenantId)
        {
            if (userId == "" || lieutenantId == null || lieutenantId == "")
                return null;

            var lieutenant = GameHandler.Lieutenants.FirstOrDefault(l => l.Id == lieutenantId);
            GameHandler.Users.FirstOrDefault(i => i.Id == userId).Lieutenants.Add(lieutenant);

            return Json(lieutenant);
        }

        public ActionResult AddMonster(string userId, string monsterId)
        {
            if (userId == "" || monsterId == null || monsterId == "")
                return null;

            var monster = GameHandler.Monsters.FirstOrDefault(l => l.Id == monsterId);
            GameHandler.Users.FirstOrDefault(i => i.Id == userId).Monsters.Add(monster);

            return Json(monster);
        }

        public ActionResult GetUser(string username)
        {
            var user = GameHandler.Users.FirstOrDefault(u => u.Name == username);
            return Json(new DashboardUserViewModel(user));
        }
    }
}