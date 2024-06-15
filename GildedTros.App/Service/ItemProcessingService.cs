using GildedTros.App.Enum;
using GildedTros.App.Helper;
using System;

namespace GildedTros.App.Service
{
    public class ItemProcessingService
    {
        // TODO 
        // Expand with all item type logic
        // Check if service is necessary or static helper (testing?)

        public Item ProcessItem(Item item)
        {
            item = UpdateQuality(item);

            return item;
        }

        private Item UpdateQuality(Item item)
        {
            if (item.HasRestrictedQuality())
            {
                return item;
            }

            var itemType = item.GetItemType();

            switch (itemType)
            {
                case ItemType.Legendary:
                    return item;
                case ItemType.Normal:
                    return item;
                case ItemType.Smelly:
                    break;
                case ItemType.GoodWine:
                    break;
                case ItemType.BackstagePass:
                    break;
                case ItemType.Unknown:
                default:
                    throw new ArgumentException($"Unknown itemtype was given: {itemType}");
            }

            return item;
        }
    }
}
