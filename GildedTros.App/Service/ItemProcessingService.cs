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
        // item as constuctor param? type collected only once
        // comments
        // tests (if type with input should be type) (not private?)

        public Item ProcessItem(Item item)
        {
            item = UpdateSellIn(item);
            item = UpdateQuality(item);

            return item;
        }

        private Item UpdateSellIn(Item item)
        {
            if (item.GetItemType() == ItemType.Legendary)
            {
                return item;
            }

            item.SellIn--;

            return item;
        }

        private Item UpdateQuality(Item item)
        {
            var itemType = item.GetItemType();

            switch (itemType)
            {
                case ItemType.Legendary:
                    break;
                case ItemType.Normal:
                case ItemType.Smelly:
                    item = DecreaseQuality(item);
                    break;
                case ItemType.GoodWine:
                case ItemType.BackstagePass:
                    item = IncreaseQuality(item);
                    break;
                case ItemType.Unknown:
                default:
                    throw new ArgumentException($"Unknown itemtype was given: {itemType}");
            }

            return item;
        }

        private Item DecreaseQuality(Item item)
        {
            var degradeBy = 1;

            if (item.GetItemType() == ItemType.Smelly)
            {
                degradeBy = 2;
            }

            if (item.SellIn < 0)
            {
                degradeBy *= 2;
            }

            item.Quality -= degradeBy;

            if (item.Quality < item.QualityMin())
            {
                item.Quality = item.QualityMin();
            }

            return item;
        }

        private Item IncreaseQuality(Item item)
        {
            item.Quality++;

            if (item.GetItemType() == ItemType.BackstagePass)
            {
                if (item.SellIn <= 10 && item.SellIn > 5)
                {
                    item.Quality++;
                }
                else if (item.SellIn <= 5 && !item.HasExpired())
                {
                    item.Quality += 2;
                }
                else if (item.HasExpired())
                {
                    item.Quality = item.QualityMin();
                }
            }

            if (item.Quality >= item.QualityMax())
            {
                item.Quality = item.QualityMax();
            }

            return item;
        }
    }
}
