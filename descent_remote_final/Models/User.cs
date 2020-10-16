using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using descent_remote_final.Models.Lieutenants;
using descent_remote_final.Models.Monsters;

namespace descent_remote_final.Models
{
    public class User
    {
        public User()
        {

        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        [Required]
        public string Name { get; set; }

        [BsonElement("character")]
        public Character Character { get; set; }

        [BsonElement("shop_cards")]
        public IList<ShopCard> ShopCards { get; set; }

        [BsonElement("skill_cards")]
        public IList<SkillCard> SkillCards { get; set; }

        [BsonElement("class_equipment_cards")]
        public IList<ClassEquipmentCard> ClassEquipmentCards { get; set; }

        [BsonElement("familiar_cards")]
        public IList<FamiliarCard> FamiliarCards { get; set; }

        [BsonElement("overlord_cards")]
        public IList<OverlordCard> OverlordCards { get; set; }

        [BsonElement("remaining_overlord_cards")]
        public IList<OverlordCard> RemainingOverlordCards { get; set; }

        [BsonElement("hand_overlord_cards")]
        public IList<OverlordCard> HandOverlordCards { get; set; }

        [BsonElement("discarded_overlord_cards")]
        public IList<OverlordCard> DiscardedOverlordCards { get; set; }

        [BsonIgnore]
        public IList<Lieutenant> Lieutenants { get; set; }

        [BsonIgnore]
        public IList<Monster> Monsters { get; set; }

        [BsonElement("overlord_relics")]
        public IList<OverlordRelicCard> OverlordRelics { get; set; }

        public bool HasSkillCard(SkillCard card)
        {
            if (SkillCards == null)
                return false;

            return SkillCards.Where(x => x.Id == card.Id).Any();
        }

        public bool HasShopCard(ShopCard card)
        {
            if (ShopCards == null)
                return false;

            return ShopCards.Where(x => x.Id == card.Id).Any();
        }

        public bool HasClassEquipmentCard(ClassEquipmentCard card)
        {
            if (ClassEquipmentCards == null)
                return false;

            return ClassEquipmentCards.Where(x => x.Id == card.Id).Any();
        }

        public bool HasFamiliarCard(FamiliarCard card)
        {
            if (FamiliarCards == null)
                return false;

            return FamiliarCards.Where(x => x.Id == card.Id).Any();
        }
    }
}
