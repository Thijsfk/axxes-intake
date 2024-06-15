using GildedTros.App.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedTros.App.Helper
{
    static class ItemTypeHelper
    {
        private static Dictionary<string, ItemType> _itemsByName = new Dictionary<string, ItemType>()
        {
            { "Ring of Cleansening Code", ItemType.Normal }
        };

        public static ItemType GetItemType(Item item)
        {
            if (_itemsByName.TryGetValue(item.Name, out ItemType value))
            {
                return value;
            }

            //throw new ArgumentException($"given Item with name '{item.Name}' is unknown and cannot be processed");
            return ItemType.Unknown;
        }
    }
}
