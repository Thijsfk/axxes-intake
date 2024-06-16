using GildedTros.App.Service;
using System.Collections.Generic;

namespace GildedTros.App
{
    public class GildedTros
    {
        IList<Item> Items;
        public GildedTros(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            var updatedList = new List<Item>();

            foreach (var item in Items)
            {
                var processor = new ItemProcessingService(item);
                var updatedItem = processor.ProcessItem();
                
                updatedList.Add(updatedItem);
            }

            Items = updatedList;
        }
    }
}
