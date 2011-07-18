using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SalesTax.Tests
{
    [TestFixture]
    public class ShoppingBasketTests
    {
        [Test]
        public void when_adding_an_item()
        {
            var item = new Item {Price = 12.49m};

            var shoppingBasket = new ShoppingBasket();
            shoppingBasket.Add(1, item);
        }

        [Test]
        public void when_generating_the_receipt_for_a_tax_exempt_item()
        {
            var item = new Item {Price = 12.49m};

            var shoppingBasket = new ShoppingBasket();
            shoppingBasket.Add(1, item);

            var receipt = shoppingBasket.Purchase();

            "It should have returned that one item was purchases".AssertThat(receipt.Items.Count(), Is.EqualTo(1));

            var purchasedItem = receipt.Items.First();
            "It should have applied no sales taxes to the purchased item".AssertThat(purchasedItem.Price, Is.EqualTo(12.49));

            "It should have a total price of 12.49".AssertThat(receipt.Total, Is.EqualTo(12.49));
            "It should have total sales tax of 0".AssertThat(receipt.SalesTaxes, Is.EqualTo(0));
        }
    }

    public class Item
    {
        public decimal Price { get; set; }
    }

    public class ShoppingBasket
    {
        public void Add(int numberOfItems, Item item)
        {
            
        }

        public Receipt Purchase()
        {
            return new Receipt();
        }
    }

    public class Receipt
    {
        public decimal Total;
        public decimal SalesTaxes;

        public IEnumerable<Item> Items { get; set; }
    }
}
