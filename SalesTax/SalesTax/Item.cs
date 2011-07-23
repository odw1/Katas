namespace SalesTax
{
    public class Item
    {
        public Category Category { get; set; }

        public decimal Price { get; set; }

        public bool IsImported { get; set; }
    }
}