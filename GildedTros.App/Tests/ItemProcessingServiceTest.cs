using GildedTros.App.Enum;
using GildedTros.App.Service;
using Moq;
using Xunit;

namespace GildedTros.App.Tests
{
    public class ItemProcessingServiceTest
    {
        [Theory]
        [InlineData(10, 10, 9, 9)]
        public void ProcessItem_NormalItem_LowersQualityAndSellIn(int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            var item = GetItemMock(sellIn, quality);
            var service = new ItemProcessingService(item, ItemType.Normal);
            var result = service.ProcessItem();

            Assert.Equal(expectedSellIn, result.SellIn);
            Assert.Equal(expectedQuality, result.Quality);
        }

        [Theory]
        [InlineData(10, 10, 10, 10)]
        [InlineData(0, 0, 0, 0)]
        [InlineData(-4, -4, -4, -4)]
        [InlineData(int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue)]
        [InlineData(int.MinValue, int.MinValue, int.MinValue, int.MinValue)]
        public void ProcessItem_LegendaryItem_DoesNotChangeSellInOrQuality(int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            var item = GetItemMock(sellIn, quality);
            var service = new ItemProcessingService(item, ItemType.Legendary);
            var result = service.ProcessItem();

            Assert.Equal(expectedSellIn, result.SellIn);
            Assert.Equal(expectedQuality, result.Quality);
        }

        [Theory]
        [InlineData(9, 10, 12)]
        [InlineData(4, 10, 13)]
        [InlineData(0, 10, 0)]
        public void ProcessItem_BackstagePassItem_QualityChangesAccordingToSellIn(int sellIn, int quality, int expected)
        {
            var item = GetItemMock(sellIn, quality);
            var service = new ItemProcessingService(item, ItemType.BackstagePass);
            var result = service.ProcessItem();

            Assert.Equal(expected, result.Quality);
        }

        /// <summary>
        /// Get a mocked Item object with values
        /// </summary>
        /// <param name="sellIn"></param>
        /// <param name="quality"></param>
        /// <returns></returns>
        private Item GetItemMock(int sellIn, int quality)
        {
            var item = new Mock<Item>();
            item.Object.Name = "MockItem";
            item.Object.SellIn = sellIn;
            item.Object.Quality = quality;

            return item.Object;
        }
    }
}
