using descent_remote_final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace descent_remote_final.Constants
{
    public class Characters
    {
        public static IList<Character> All => new List<Character>
        {
            GrisbanTheThirsty,
            JainFairwood,
            WidowTarha,
            Ashirian,
            Syndrael,
            AugurGrisom,
            AvricAlbright,
            LeoricOfTheBook,
            RogannaTheShade,
            TombleBurrowell
        };

        public static Character GrisbanTheThirsty => new Character
        {
            Archetype = Archetype.Warrior,
            Name = "Grisban the Thirsty",
            ImageLocation = "~/images/characters/grisban_the_thirsty_full.jpg",
            Speed = 3,
            Health = 14,
            CurrentHealth = 14,
            Stamina = 4,
            CurrentStamina = 4,
            DefenseDice = new List<DefenseDie> { DefenseDie.Gray },
            Might = 5,
            Willpower = 3,
            Knowledge = 2,
            Awareness = 1,
            HeroAbility = "Each time you perform a rest action, you may immediately discard 1 Condition card from yourself.",
            HeroicFeat = "Use during your turn to perform 1 attack action. This is in addition to your 2 actions on your turn.",
            HeroicFeatUsed = false
        };

        public static Character JainFairwood => new Character
        {
            Archetype = Archetype.Scout,
            Name = "Jain Fairwood",
            ImageLocation = "~/images/characters/jain_fairwood_full.png",
            Speed = 5,
            Health = 8,
            CurrentHealth = 8,
            Stamina = 5,
            CurrentStamina = 5,
            DefenseDice = new List<DefenseDie> { DefenseDie.Gray },
            Might = 2,
            Willpower = 2,
            Knowledge = 3,
            Awareness = 4,
            HeroAbility = "When you suffer any amount of ++heart++ from an attack, you may choose to suffer some or all of that amount as <<fatigue>> instead; you cannot suffer <<fatigue>> in excess of your Stamina. }",
            HeroicFeat = "<<Action>>: You may move double your Speed and perform an attack. This attack may be performed before, after, or during this movement.",
            HeroicFeatUsed = false
        };

        public static Character WidowTarha => new Character
        {
            Archetype = Archetype.Mage,
            Name = "Widow Tarha",
            ImageLocation = "~/images/characters/widow_tarha_full.jpg",
            Speed = 4,
            Health = 10,
            CurrentHealth = 10,
            Stamina = 4,
            CurrentStamina = 4,
            DefenseDice = new List<DefenseDie> { DefenseDie.Gray },
            Might = 2,
            Willpower = 3,
            Knowledge = 4,
            Awareness = 2,
            HeroAbility = "Once per round, after you roll dice for an attack, you may reroll 1 attack or power die. You must keep the new result.",
            HeroicFeat = "<<Action>>: Perform an attack. This attack affects 2 different monsters in your line of sight. 1 attack roll is made but each monster rolls defense dice separately. Both monsters are considered targets of your attack.",
            HeroicFeatUsed = false
        };

        public static Character Ashirian => new Character
        {
            Archetype = Archetype.Healer,
            Name = "Ashirian",
            ImageLocation = "~/images/characters/ashirian_full.jpg",
            Speed = 5,
            Health = 10,
            CurrentHealth = 10,
            Stamina = 4,
            CurrentStamina = 4,
            DefenseDice = new List<DefenseDie> { DefenseDie.Gray },
            Might = 2,
            Willpower = 3,
            Knowledge = 2,
            Awareness = 4,
            HeroAbility = "When a minion monster begins its activation adjacent to you, it is Stunned.",
            HeroicFeat = "<<Action>>: Choose a monster within 3 spaces of you. Each monster of that group is Stunned.",
            HeroicFeatUsed = false
        };

        public static Character Syndrael => new Character
        {
            Archetype = Archetype.Warrior,
            Name = "Syndrael",
            ImageLocation = "~/images/characters/syndrael.png",
            Speed = 4,
            Health = 12,
            CurrentHealth = 12,
            Stamina = 4,
            CurrentStamina = 4,
            DefenseDice = new List<DefenseDie> { DefenseDie.Gray },
            Might = 4,
            Willpower = 2,
            Knowledge = 3,
            Awareness = 2,
            HeroAbility = "If you have not moved during this turn, you recover 2 ++fatigue++ at the end of your turn.",
            HeroicFeat = "Use during your turn to choose a hero within 3 spaces of you. You and that hero may each immediately perform a move action. This is in addition to the 2 actions each hero receives on his turn.",
            HeroicFeatUsed = false
        };
        public static Character TombleBurrowell => new Character
        {
            Archetype = Archetype.Scout,
            Name = "Tomble Burrowell",
            ImageLocation = "~/images/characters/tomble_burrowell.jpg",
            Speed = 4,
            Health = 8,
            CurrentHealth = 8,
            Stamina = 5,
            CurrentStamina = 5,
            DefenseDice = new List<DefenseDie> { DefenseDie.Gray },
            Might = 1,
            Willpower = 3,
            Knowledge = 2,
            Awareness = 5,
            HeroAbility = "If you are attacked while adjacent to at least one other hero, you may choose an adjacent hero and add the defense pool of that hero to your own.",
            HeroicFeat = "++action++ : Remove your figure from the map and place a hero token in your space. At the start of your next turn, place your figure in any empty space within 4 spaces of your hero token.",
            HeroicFeatUsed = false
        };
        public static Character LeoricOfTheBook => new Character
        {
            Archetype = Archetype.Mage,
            Name = "Leoric of the Book",
            ImageLocation = "~/images/characters/leoric_of_the_book.jpg",
            Speed = 4,
            Health = 8,
            CurrentHealth = 8,
            Stamina = 5,
            CurrentStamina = 5,
            DefenseDice = new List<DefenseDie> { DefenseDie.Gray },
            Might = 1,
            Willpower = 2,
            Knowledge = 5,
            Awareness = 3,
            HeroAbility = "Each monster within 3 spaces of you receives -1 ++heart++ on all attack rolls (to a minimum of 1).",
            HeroicFeat = "++action++ : Perform an attack with a Magic weapon. This attack ignores range and targets each figure adjacent to you. 1 attack roll is made but each figure rolls defense dice separately.",
            HeroicFeatUsed = false
        };
        public static Character AvricAlbright => new Character
        {
            Archetype = Archetype.Healer,
            Name = "Avric Albright",
            ImageLocation = "~/images/characters/avric_albright.png",
            Speed = 4,
            Health = 12,
            CurrentHealth = 12,
            Stamina = 4,
            CurrentStamina = 4,
            DefenseDice = new List<DefenseDie> { DefenseDie.Gray },
            Might = 2,
            Willpower = 4,
            Knowledge = 3,
            Awareness = 2,
            HeroAbility = "Each hero within 3 spaces of you (including yourself) gains \"++surge++: Recover 1 ++heart++\" on all attack rolls.",
            HeroicFeat = "++action++ : Roll 2 red power dice. Each hero within 3 spaces of you (including yourself) may recover ++heart++ equal to the ++heart++ rolled.",
            HeroicFeatUsed = false
        };
        public static Character AugurGrisom => new Character
        {
            Archetype = Archetype.Healer,
            Name = "Augur Grisom",
            ImageLocation = "~/images/characters/augur_grisom.jpg",
            Speed = 3,
            Health = 12,
            CurrentHealth = 12,
            Stamina = 5,
            CurrentStamina = 5,
            DefenseDice = new List<DefenseDie> { DefenseDie.Gray },
            Might = 4,
            Willpower = 3,
            Knowledge = 2,
            Awareness = 2,
            HeroAbility = "Each other hero within 3 spaces of you gains: Each time a monster misses or deals no ++heart++ on an attack targeting you, recover 1 ++heart++.",
            HeroicFeat = "Use during your turn. Each hero in your line of sight recovers 2 ++heart++ and 2 ++fatigue++.",
            HeroicFeatUsed = false
        };
        public static Character RogannaTheShade => new Character
        {
            Archetype = Archetype.Scout,
            Name = "Roganna the Shade",
            ImageLocation = "~/images/characters/roganna_the_shade.jpg",
            Speed = 5,
            Health = 10,
            CurrentHealth = 10,
            Stamina = 4,
            CurrentStamina = 4,
            DefenseDice = new List<DefenseDie> { DefenseDie.Gray },
            Might = 2,
            Willpower = 4,
            Knowledge = 2,
            Awareness = 3,
            HeroAbility = "Each of your attacks targeting a monster that is not adjacent to any other hero gains +1 ++heart++.",
            HeroicFeat = "Use at the end of your turn. Until the start of your next turn, each hero within 3 spaces of you may only be targeted by an attack if the attacking monster is adjacent to the targeted hero.",
            HeroicFeatUsed = false
        };
    }
}
