using GildedTros.App;
using GildedTros.App.Enum;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace GildedTros.App.Helper
{
    static class ItemExtensions
    {
        private static readonly int _qualityMax = 50;
        private static readonly int _qualityMin = 0;

        private static readonly Dictionary<string, ItemType> _itemsByName = new Dictionary<string, ItemType>()
        {
            { "Ring of Cleansening Code", ItemType.Normal },
            { "Good Wine", ItemType.GoodWine },
            { "Elixir of the SOLID", ItemType.Normal },
            { "B-DAWG Keychain", ItemType.Legendary },
            { "Backstage passes for Re:factor", ItemType.BackstagePass },
            { "Backstage passes for HAXX", ItemType.BackstagePass },
            { "Duplicate Code", ItemType.Smelly },
            { "Long Methods", ItemType.Smelly },
            { "Ugly Variable Names", ItemType.Smelly }
        };

        public static int QualityMax(this Item item)
        {
            return _qualityMax;
        }
        
        public static int QualityMin(this Item item)
        {
            return _qualityMin;
        }

        public static ItemType GetItemType(this Item item)
        {
            if (_itemsByName.TryGetValue(item.Name, out ItemType value))
            {
                return value;
            }

            //throw new ArgumentException($"given Item with name '{item.Name}' is unknown and cannot be processed");
            return ItemType.Unknown;
        }

        public static bool HasExpired(this Item item)
        {
            return item.SellIn < 0;
        }
    }
}
