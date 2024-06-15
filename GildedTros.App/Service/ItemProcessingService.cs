using GildedTros.App.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedTros.App.Service
{
    public class ItemProcessingService
    {
        public Item ProcessItem(Item item, ItemType type)
        {
            item.Quality += 1;

            return item;
        }
    }
}
