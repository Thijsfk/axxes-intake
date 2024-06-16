using GildedTros.App.Enum;
using System;
using System.Collections.Generic;

namespace GildedTros.App.Helper
{
    static class ItemExtensions
    {
        private static readonly int _qualityMax = 50;
        private static readonly int _qualityMin = 0;

        private static readonly Dictionary<string, ItemType> _itemsByName = new()
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

        /// <summary>
        /// Get the maximum allowed quality value of the item
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Maximum Item Quality Value</returns>
        public static int QualityMax(this Item item)
        {
            return _qualityMax;
        }

        /// <summary>
        /// Get the minimum allowed quality value of the item
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Minimum Item Quality Value</returns>
        public static int QualityMin(this Item item)
        {
            return _qualityMin;
        }

        /// <summary>
        /// Get the type of the item based on its name
        /// </summary>
        /// <param name="item"></param>
        /// <returns>The type of the item (ItemType Enum)</returns>
        /// <exception cref="ArgumentException"></exception>
        public static ItemType GetItemType(this Item item)
        {
            if (_itemsByName.TryGetValue(item.Name, out ItemType value))
            {
                return value;
            }

            throw new ArgumentException($"given Item with name '{item.Name}' is unknown and cannot be processed");
        }

        /// <summary>
        /// Check if the item is Expired
        /// </summary>
        /// <param name="item"></param>
        /// <returns>True or False on expiry</returns>
        public static bool HasExpired(this Item item)
        {
            return item.SellIn < 0;
        }
    }
}
