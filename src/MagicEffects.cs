using EpicLootAPI;

namespace EpicLootLeslieAlphaTest.src
{
    public static class MagicEffects
    {
        public static void Init()
        {
            var ancestralSlam = new MagicItemEffectDefinition("AncestralSlam", "Ancestral Slam", "Reduces damage of weapon. Summons ancestral spirit to mirror attack for each enemy hit");
            ancestralSlam.Requirements.AllowedItemTypes.Add("TwoHandedWeapon");
            ancestralSlam.Requirements.AllowedRarities.Add(ItemRarity.Epic, ItemRarity.Legendary, ItemRarity.Mythic);
            ancestralSlam.SelectionWeight = 1;
        }
    }
}
