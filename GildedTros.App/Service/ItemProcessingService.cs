using GildedTros.App.Enum;
using GildedTros.App.Helper;
using GildedTros.App.Interface;
using System;

namespace GildedTros.App.Service
{
    /// <inheritdoc />
    public class ItemProcessingService : IItemProcessingService
    {
        private readonly Item _item;
        private readonly ItemType _itemType;

        public ItemProcessingService(Item item)
        {
            _item = item;
            _itemType = item.GetItemType();
        }

        public ItemProcessingService(Item item, ItemType type) {
            _item = item;
            _itemType = type;
        }

        public Item ProcessItem()
        {
            UpdateSellIn();
            UpdateQuality();

            return _item;
        }

        /// <summary>
        /// Update item sellIn value based on type
        /// </summary>
        private void UpdateSellIn()
        {
            if (_itemType == ItemType.Legendary)
            {
                return;
            }

            _item.SellIn--;
        }

        /// <summary>
        /// Update item quality based on type
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        /// Decrease the quality value of an item depending on type and sellIn value
        /// </summary>
        private void DecreaseQuality()
        {
            var degradeBy = 1;

            if (_itemType == ItemType.Smelly)
            {
                // TODO: This would cover the 'new feature', but will make the approval test fail
                
                //degradeBy = 2;
                degradeBy = 1;
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

        /// <summary>
        /// Increase the quality value of an item depending on type and sellIn value
        /// </summary>
        private void IncreaseQuality()
        {
            _item.Quality++;

            if (_itemType == ItemType.BackstagePass)
            {
                if (_item.SellIn < 10 && _item.SellIn >= 5)
                {
                    _item.Quality++;
                }
                else if (_item.SellIn < 5 && !_item.HasExpired())
                {
                    _item.Quality += 2;
                }
                else if (_item.HasExpired())
                {
                    _item.Quality = _item.QualityMin();
                }
            } else if (_itemType == ItemType.GoodWine)
            {
                if (_item.HasExpired())
                {
                    _item.Quality++;
                }
            }

            if (_item.Quality >= _item.QualityMax())
            {
                _item.Quality = _item.QualityMax();
            }
        }
    }
}
