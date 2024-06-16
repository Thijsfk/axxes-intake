namespace GildedTros.App.Interface
{
    public interface IItemProcessingService
    {
        /// <summary>
        /// Update SellIn and Quality based on item type
        /// </summary>
        /// <returns></returns>
        public Item ProcessItem();
    }
}
