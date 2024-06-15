using GildedTros.App.Enum;
using System.Collections.Generic;

namespace GildedTros.App.Helper
{
    static class ItemExtensions
    {
        private static readonly Dictionary<string, ItemType> _itemsByName = new Dictionary<string, ItemType>()
        {
            { "Ring of Cleansening Code", ItemType.Normal }
        };

        public static ItemType GetItemType(this Item item)
        {
            if (_itemsByName.TryGetValue(item.Name, out ItemType value))
            {
                return value;
            }

            //throw new ArgumentException($"given Item with name '{item.Name}' is unknown and cannot be processed");
            return ItemType.Unknown;
        }

        public static bool HasRestrictedQuality(this Item item)
        {
            if (item.Quality < 50 && item.Quality != 0)
            {
                return false;
            }

            return true;
        }
    }
}
