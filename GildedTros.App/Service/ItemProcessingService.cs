using GildedTros.App.Enum;
using System;

namespace GildedTros.App.Service
{
    public class ItemProcessingService
    {
        // TODO 
        // Expand with all item type logic
        // Check if service is necessary or static helper (testing?)

        public Item ProcessItem(Item item, ItemType type)
        {
            item.Quality += 1;

            return item;
        }

        private Item UpdateQuality(Item item, ItemType type)
        {
            if (hasRestrictedQuality(item))
            {
                return item;
            }

            switch (type)
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
                    throw new ArgumentException($"Unknown itemtype was given: {type}");
            }
        }

        private bool hasRestrictedQuality(Item item)
        {
            if (item.Quality < 50 && item.Quality != 0)
            {
                return false;
            }

            return true;
        }
    }
}
