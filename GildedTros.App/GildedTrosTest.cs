using Xunit;
using System.Collections.Generic;

namespace GildedTros.App
{
    public class GildedTrosTest
    {
        [Fact]
        public void UpdateQuality_NormalItem_DecresesInQualityAndSellInOverTime()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Ring of Cleansening Code", SellIn = 20, Quality = 30 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            
            // 1 day
            Assert.Equal(19, Items[0].SellIn);
            Assert.Equal(29, Items[0].Quality);

            // 20 days
            for (var i = 0; i < 19; i++)
            {
                app.UpdateQuality();
            }

            Assert.Equal(0, Items[0].SellIn);
            Assert.Equal(10, Items[0].Quality);

            // 40 days
            for (var i = 0; i < 20; i++)
            {
                app.UpdateQuality();
            }

            Assert.Equal(-20, Items[0].SellIn);
            Assert.Equal(0, Items[0].Quality);
        }

    }
}