using GildedTros.App.Enum;
using GildedTros.App.Service;
using Moq;
using Xunit;

namespace GildedTros.App.Tests
{
    public class ItemProcessingServiceTest
    {
        [Theory]
        [InlineData(10, 10)]
        [InlineData(0, 0)]
        [InlineData(-4, -4)]
        [InlineData(int.MaxValue, int.MaxValue)]
        [InlineData(int.MinValue, int.MinValue)]
        public void ProcessItem_LegendaryItem_DoesNotChangeSellIn(int sellIn, int expected)
        {
            var item = new Mock<Item>();
            item.Object.Name = "LegendaryItem";
            item.Object.SellIn = sellIn;

            var service = new ItemProcessingService(item.Object, ItemType.Legendary);
            service.ProcessItem();

            Assert.Equal(sellIn, expected);
        }

        [Theory]
        [InlineData(10, 10)]
        [InlineData(0, 0)]
        [InlineData(-4, -4)]
        [InlineData(int.MaxValue, int.MaxValue)]
        [InlineData(int.MinValue, int.MinValue)]
        public void ProcessItem_LegendaryItem_DoesNotChangeQuality(int quality, int expected)
        {
            var item = new Mock<Item>();
            item.Object.Name = "LegendaryItem";
            item.Object.Quality = quality;

            var service = new ItemProcessingService(item.Object, ItemType.Legendary);
            service.ProcessItem();

            Assert.Equal(quality, expected);
        }


        // backstage increase check (1, 2, 3)
    }
}
