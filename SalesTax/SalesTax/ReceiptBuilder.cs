using System.Collections.Generic;
using System.Text;

namespace SalesTax
{
    public interface IReceiptBuilder
    {
        string Build();
        IReceiptBuilder WithSalesTaxes(decimal salesTaxes);
        IReceiptBuilder WithTotalPrice(decimal totalPrice);
        IReceiptBuilder WithPurchasedItem(string itemDescription, bool isItemImported, decimal purchasePrice);
    }

    public class ReceiptBuilder : IReceiptBuilder
    {
        private readonly List<PurchasedItem> _purchasedItems;
        private decimal _salesTaxes;
        private decimal _totalPrice;

        public ReceiptBuilder()
        {
            _purchasedItems = new List<PurchasedItem>();
        }

        public string Build()
        {
            var stringBuilder = new StringBuilder();

            foreach (var purchasedItem in _purchasedItems)
            {
                if (purchasedItem.IsItemImported)
                {
                    stringBuilder.AppendLine(string.Format("1 imported {0}: {1}", purchasedItem.ItemDescription, purchasedItem.PurchasePrice.ToString("N2")));
                }
                else
                {
                    stringBuilder.AppendLine(string.Format("1 {0}: {1}", purchasedItem.ItemDescription, purchasedItem.PurchasePrice.ToString("N2")));
                }
            }

            stringBuilder.AppendLine("Sales Taxes: " + _salesTaxes.ToString("N2"));
            stringBuilder.AppendLine("Total: " + _totalPrice.ToString("N2"));

            var receipt = stringBuilder.ToString();
            return receipt;
        }

        public IReceiptBuilder WithSalesTaxes(decimal salesTaxes)
        {
            _salesTaxes = salesTaxes;
            return this;
        }

        public IReceiptBuilder WithTotalPrice(decimal totalPrice)
        {
            _totalPrice = totalPrice;
            return this;
        }

        public IReceiptBuilder WithPurchasedItem(string itemDescription, bool isItemImported, decimal purchasePrice)
        {
            var purchasedItem = new PurchasedItem { ItemDescription = itemDescription, IsItemImported = isItemImported, PurchasePrice = purchasePrice };
            _purchasedItems.Add(purchasedItem);

            return this;
        }

        private class PurchasedItem
        {
            public string ItemDescription { get; set; }
            public bool IsItemImported { get; set; }
            public decimal PurchasePrice { get; set; }
        }
    }
}