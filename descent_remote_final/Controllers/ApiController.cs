﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using descent_remote_final.Models.Lieutenants;
using descent_remote_final.Services;
using Microsoft.AspNetCore.Mvc;

namespace descent_remote_final.Controllers
{
    public class ApiController : Controller
    {
        private readonly GameHandler _gameHandler;

        public ApiController(GameHandler gameHandler)
        {
            _gameHandler = gameHandler;
        }

        // GET: Api/AddHealth
        public ActionResult AddHealth(string id)
        {
            var user = _gameHandler.Users.First(u => u.Id == id);

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
            var user = _gameHandler.Users.First(u => u.Id == id);

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
            var user = _gameHandler.Users.First(u => u.Id == id);

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
            var user = _gameHandler.Users.First(u => u.Id == id);

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
            var user = _gameHandler.Users.First(u => u.Id == userId);

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
            var user = _gameHandler.Users.First(u => u.Id == userId);

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
            var user = _gameHandler.Users.First(u => u.Id == userId);

            if (user.Character == null)
                return null;

            var familiarCard = user.FamiliarCards.FirstOrDefault(card => card.Id == familiarId);

            if (familiarCard.CurrentHealth <= 0)
                familiarCard.CurrentHealth = familiarCard.Health;

            return Json(familiarCard.CurrentHealth);
        }

        public ActionResult ExhaustHeroicFeat(string userId)
        {
            var user = _gameHandler.Users.First(u => u.Id == userId);

            if (user.Character == null)
                return Json(false);

            if (user.Character.HeroicFeatUsed)
                return Json(false);

            user.Character.HeroicFeatUsed = true;
            return Json(true);
        }

        public ActionResult ExhaustCard(string userId, string cardId)
        {
            var user = _gameHandler.Users.FirstOrDefault(u => u.Id == userId);

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
            var user = _gameHandler.Users.FirstOrDefault(u => u.Id == userId);

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
            var user = _gameHandler.Users.FirstOrDefault(u => u.Id == userId);

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
            var user = _gameHandler.Users.FirstOrDefault(u => u.Id == userId);

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
            var user = _gameHandler.Users.First(u => u.Id == userId);

            user.Character.HeroicFeatUsed = false;
            return Json(true);
        }

        public ActionResult ResetGame()
        {
            var users = _gameHandler.Users;

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
            return Json(_gameHandler.Lieutenants);
        }

        public ActionResult GetMonsters()
        {
            return Json(_gameHandler.Monsters);
        }

        public ActionResult GetUsers()
        {
            return Json(_gameHandler.Users.Select(u => u.Name).ToArray());
        }

        public ActionResult AddLieutenant(string userId, string lieutenantId)
        {
            if (userId == "" || lieutenantId == null || lieutenantId == "")
                return null;

            var lieutenant = _gameHandler.Lieutenants.FirstOrDefault(l => l.Id == lieutenantId);
            _gameHandler.Users.FirstOrDefault(i => i.Id == userId).Lieutenants.Add(lieutenant);

            return Json(lieutenant);
        }

        public ActionResult AddMonster(string userId, string monsterId)
        {
            if (userId == "" || monsterId == null || monsterId == "")
                return null;

            var monster = _gameHandler.Monsters.FirstOrDefault(l => l.Id == monsterId);
            _gameHandler.Users.FirstOrDefault(i => i.Id == userId).Monsters.Add(monster);

            return Json(monster);
        }
    }
}