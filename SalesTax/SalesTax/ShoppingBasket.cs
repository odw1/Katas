using System.Collections.Generic;

namespace SalesTax
{
    public class ShoppingBasket
    {
        private readonly ITaxCalculator _taxCalculator;
        private readonly IReceiptBuilder _receiptBuilder;
        private readonly List<Item> _itemsAddedToBasket; 

        public ShoppingBasket(ITaxCalculator taxCalculator, IReceiptBuilder receiptBuilder)
        {
            _taxCalculator = taxCalculator;
            _receiptBuilder = receiptBuilder;
            _itemsAddedToBasket = new List<Item>();
        }

        public void AddToBasket(Item item)
        {
            _itemsAddedToBasket.Add(item);
        }

        public string Purchase()
        {
            decimal salesTaxes = 0;
            decimal totalPrice = 0;

            foreach (var item in _itemsAddedToBasket)
            {
                var itemSalesTaxes = _taxCalculator.CalculateTax(item.Price, item.Category, item.IsImported);

                salesTaxes = itemSalesTaxes;
                totalPrice = (item.Price + itemSalesTaxes);
                _receiptBuilder.WithPurchasesItem(item.Category, item.IsImported, itemSalesTaxes);
            }

            _receiptBuilder.WithSalesTaxes(salesTaxes);
            _receiptBuilder.WithTotalPrice(totalPrice);

            return _receiptBuilder.Build();
        }
    }
}