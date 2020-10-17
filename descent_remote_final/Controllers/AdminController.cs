using System;
using System.Collections.Generic;
using System.Linq;
using descent_remote_final.Constants;
using descent_remote_final.Models;
using descent_remote_final.Models.Lieutenants;
using descent_remote_final.Models.Monsters;
using descent_remote_final.Services;
using descent_remote_final.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace descent_remote_final.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserService userService;
        private readonly ShopCardService shopCardService;
        private readonly SkillCardService skillCardService;
        private readonly ClassEquipmentCardService classEquipmentCardService;
        private readonly FamiliarCardService familiarCardService;
        private readonly CharacterService characterService;
        private readonly GameHandler _gameHandler;

        public AdminController(UserService userService, 
            ShopCardService shopCardService, 
            SkillCardService skillCardService, 
            ClassEquipmentCardService classEquipmentCardService, 
            FamiliarCardService familiarCardService,
            GameHandler gameHandler,
            CharacterService characterService)
        {
            this.userService = userService;
            this.shopCardService = shopCardService;
            this.skillCardService = skillCardService;
            this.classEquipmentCardService = classEquipmentCardService;
            this.familiarCardService = familiarCardService;
            this._gameHandler = gameHandler;
            this.characterService = characterService;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View(userService.Get());
        }

        // GET: Admin/Details/5
        public ActionResult Details(string id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            var user = new User();
            var shopCards = shopCardService.Get();
            var skillCards = skillCardService.Get();
            var classEquipmentCards = classEquipmentCardService.Get();
            var familiarCards = familiarCardService.Get();
            return View(new UserEditViewModel(user, shopCards, skillCards, classEquipmentCards, familiarCards));
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserEditViewModel viewModel)
        {
            try
            {
                var user = new User();
                user.Name = viewModel.Name;
                user.Character = characterService.GetByName(viewModel.CharacterName);
                user.SkillCards = new List<SkillCard>();
                user.ShopCards = new List<ShopCard>();
                user.ClassEquipmentCards = new List<ClassEquipmentCard>();
                user.FamiliarCards = new List<FamiliarCard>();
                user.OverlordCards = new List<OverlordCard>();
                user.RemainingOverlordCards = new List<OverlordCard>();
                user.HandOverlordCards = new List<OverlordCard>();
                user.DiscardedOverlordCards = new List<OverlordCard>();
                // user.Lieutenants = new List<Lieutenant>();
                // user.Monsters = new List<Monster>();
                user.OverlordRelics = new List<OverlordRelicCard>();

                // Set newly selected SkillCards based on user selection in the UI
                var allSkillCards = skillCardService.Get();
                var selectedSkillCards = viewModel.SkillCards.Where(x => x.Selected);

                foreach (var card in allSkillCards)
                {
                    if (selectedSkillCards.Where(x => x.DisplayName == card.Name).Any())
                        user.SkillCards.Add(card);
                }

                // Set newly selected ClassEquipmentCards based on user selection in the UI
                var allClassEquipmentCards = classEquipmentCardService.Get();
                var selectedClassEquipmentCards = viewModel.ClassEquipmentCards.Where(x => x.Selected);

                foreach (var card in allClassEquipmentCards)
                {
                    if (selectedClassEquipmentCards.Where(x => x.DisplayName == card.Name).Any())
                        user.ClassEquipmentCards.Add(card);
                }

                // Set newly selected ShopCards based on user selection in the UI
                var allShopCards = shopCardService.Get();
                var selectedShopCards = viewModel.ShopCards.Where(x => x.Selected);

                foreach (var card in allShopCards)
                {
                    if (selectedShopCards.Where(x => x.DisplayName == card.Name).Any())
                        user.ShopCards.Add(card);
                }

                // Set newly selected FamiliarCards based on user selection in the UI
                var allFamiliarCards = familiarCardService.Get();
                var selectedFamiliarCards = viewModel.FamiliarCards.Where(x => x.Selected);

                foreach (var card in allFamiliarCards)
                {
                    if (selectedFamiliarCards.Where(x => x.DisplayName == card.Name).Any())
                        user.FamiliarCards.Add(card);
                }

                userService.Create(user);
                _gameHandler.Users.Add(user);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(string id)
        {
            var user = userService.Get(id);
            var shopCards = shopCardService.Get();
            var skillCards = skillCardService.Get();
            var classEquipmentCards = classEquipmentCardService.Get();
            var familiarCards = familiarCardService.Get();
            return View(new UserEditViewModel(user, shopCards, skillCards, classEquipmentCards, familiarCards));
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, UserEditViewModel viewModel)
        {
            try
            {
                var dbUser = userService.Get(id);
                var appUser = _gameHandler.Users.SingleOrDefault(u => u.Id == id);

                // Update user name
                dbUser.Name = viewModel.Name;
                appUser.Name = viewModel.Name;

                // Update the character

                var character = characterService.GetByName(viewModel.CharacterName);
                dbUser.Character = character;
                appUser.Character = character;

                // Reset user cards
                dbUser.SkillCards = new List<SkillCard>();
                dbUser.ShopCards = new List<ShopCard>();
                dbUser.ClassEquipmentCards = new List<ClassEquipmentCard>();
                dbUser.FamiliarCards = new List<FamiliarCard>();
                appUser.SkillCards = new List<SkillCard>();
                appUser.ShopCards = new List<ShopCard>();
                appUser.ClassEquipmentCards = new List<ClassEquipmentCard>();
                appUser.FamiliarCards = new List<FamiliarCard>();

                // Set newly selected SkillCards based on user selection in the UI
                var allSkillCards = skillCardService.Get();
                var selectedSkillCards = viewModel.SkillCards.Where(x => x.Selected);
                
                foreach (var card in allSkillCards)
                {
                    if (selectedSkillCards.Where(x => x.DisplayName == card.Name).Any()){
                        dbUser.SkillCards.Add(card);
                        appUser.SkillCards.Add(card);
                    }
                }

                // Set newly selected ClassEquipmentCards based on user selection in the UI
                var allClassEquipmentCards = classEquipmentCardService.Get();
                var selectedClassEquipmentCards = viewModel.ClassEquipmentCards.Where(x => x.Selected);

                foreach (var card in allClassEquipmentCards)
                {
                    if (selectedClassEquipmentCards.Where(x => x.DisplayName == card.Name).Any()){
                        dbUser.ClassEquipmentCards.Add(card);
                        appUser.ClassEquipmentCards.Add(card);
                    } 
                }

                // Set newly selected ShopCards based on user selection in the UI
                var allShopCards = shopCardService.Get();
                var selectedShopCards = viewModel.ShopCards.Where(x => x.Selected);

                foreach (var card in allShopCards)
                {
                    if (selectedShopCards.Where(x => x.DisplayName == card.Name).Any()){
                        dbUser.ShopCards.Add(card);
                        appUser.ShopCards.Add(card);
                    }
                }

                // Set newly selected FamiliarCards based on user selection in the UI
                var allFamiliarCards = familiarCardService.Get();
                var selectedFamiliarCards = viewModel.FamiliarCards.Where(x => x.Selected);

                foreach (var card in allFamiliarCards)
                {
                    if (selectedFamiliarCards.Where(x => x.DisplayName == card.Name).Any()){
                        dbUser.FamiliarCards.Add(card);
                        appUser.FamiliarCards.Add(card);
                    }
                }

                userService.Update(id, dbUser);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IList<SkillCard> GetSkillCards()
        {
            return skillCardService.Get();
        }
    }
}