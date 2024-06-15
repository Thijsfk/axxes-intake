using GildedTros.App.Enum;
using GildedTros.App.Helper;
using System;

namespace GildedTros.App.Service
{
    public class ItemProcessingService
    {
        private readonly Item _item;
        private readonly ItemType _itemType;

        public ItemProcessingService(Item item) {
            _item = item;
            _itemType = item.GetItemType();
        }

        // TODO 
        // Expand with all item type logic
        // Check if service is necessary or static helper (testing?)
        // item as constuctor param? type collected only once
        // comments
        // tests (if type with input should be type) (not private?)

        public Item ProcessItem()
        {
            UpdateSellIn();
            UpdateQuality();

            return _item;
        }

        private void UpdateSellIn()
        {
            if (_itemType == ItemType.Legendary)
            {
                return;
            }

            _item.SellIn--;
        }

        private void UpdateQuality()
        {
            switch (_itemType)
            {
                case ItemType.Legendary:
                    break;
                case ItemType.Normal:
                case ItemType.Smelly:
                    DecreaseQuality();
                    break;
                case ItemType.GoodWine:
                case ItemType.BackstagePass:
                    IncreaseQuality();
                    break;
                case ItemType.Unknown:
                default:
                    throw new ArgumentException($"Unknown itemtype in instance: {_itemType}");
            }
        }

        private void DecreaseQuality()
        {
            var degradeBy = 1;

            if (_itemType == ItemType.Smelly)
            {
                degradeBy = 2;
            }

            if (_item.SellIn < 0)
            {
                degradeBy *= 2;
            }

            _item.Quality -= degradeBy;

            if (_item.Quality < _item.QualityMin())
            {
                _item.Quality = _item.QualityMin();
            }
        }

        private void IncreaseQuality()
        {
            _item.Quality++;

            if (_itemType == ItemType.BackstagePass)
            {
                if (_item.SellIn <= 10 && _item.SellIn > 5)
                {
                    _item.Quality++;
                }
                else if (_item.SellIn <= 5 && !_item.HasExpired())
                {
                    _item.Quality += 2;
                }
                else if (_item.HasExpired())
                {
                    _item.Quality = _item.QualityMin();
                }
            }

            if (_item.Quality >= _item.QualityMax())
            {
                _item.Quality = _item.QualityMax();
            }
        }
    }
}
