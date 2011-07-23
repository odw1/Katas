namespace SalesTax
{
    public interface IReceiptBuilder
    {
        string Build();
        IReceiptBuilder WithSalesTaxes(decimal salesTaxes);
        IReceiptBuilder WithTotalPrice(decimal totalPrice);
        IReceiptBuilder WithPurchasesItem(Category itemCategory, bool isItemImported, decimal purchasePrice);
    }

    public class ReceiptBuilder : IReceiptBuilder
    {
        public string Build()
        {
            return null;
        }

        public IReceiptBuilder WithSalesTaxes(decimal salesTaxes)
        {
            return null;
        }

        public IReceiptBuilder WithTotalPrice(decimal totalPrice)
        {
            return null;
        }

        public IReceiptBuilder WithPurchasesItem(Category itemCategory, bool isItemImported, decimal purchasePrice)
        {
            return null;
        }
    }
}