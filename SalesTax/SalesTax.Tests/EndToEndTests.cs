using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SalesTax.Tests
{
    [TestFixture]
    [Category("endtoend")]
    public class EndToEndTests
    {
        private ShoppingBasket _shoppingBasket;

        [SetUp]
        public void SetUp()
        {
            var taxCalculator = new TaxCalculator();
            var receiptBuilder = new ReceiptBuilder();

            _shoppingBasket = new ShoppingBasket(taxCalculator, receiptBuilder);
        }

        [Test]
        public void when_purchasing_scenario1()
        {
            //Input 1:
            //1 book at 12.49
            //1 music CD at 14.99
            //1 chocolate bar at 0.85

            _shoppingBasket.AddToBasket(new Item { Category = Category.Book, Description = "book", IsImported = false, Price = 12.49m });
            _shoppingBasket.AddToBasket(new Item { Category = Category.MusicCD, Description = "music CD", IsImported = false, Price = 14.99m });
            _shoppingBasket.AddToBasket(new Item { Category = Category.Food, Description = "chocolate bar", IsImported = false, Price = 0.85m });

            var receipt = _shoppingBasket.Purchase();

            var exceptedReceipt =
                "1 book: 12.49\r\n" +
                "1 music CD: 16.49\r\n" +
                "1 chocolate bar: 0.85\r\n" +
                "Sales Taxes: 1.50\r\n" +
                "Total: 29.83\r\n";
           
            "It should generate the correct receipt".AssertThat(receipt, Is.EqualTo(exceptedReceipt));
        }

        [Test]
        public void when_purchasing_scenario2()
        {
            _shoppingBasket.AddToBasket(new Item { Category = Category.Food, Description = "box of chocolates", IsImported = true, Price = 10.00m });
            _shoppingBasket.AddToBasket(new Item { Category = Category.Perfume, Description = "bottle of perfume", IsImported = true, Price = 47.50m });

            var receipt = _shoppingBasket.Purchase();

            var exceptedReceipt =
                "1 imported box of chocolates: 10.50\r\n" +
                "1 imported bottle of perfume: 54.65\r\n" +
                "Sales Taxes: 7.65\r\n" +
                "Total: 65.15\r\n";

            "It should generate the correct receipt".AssertThat(receipt, Is.EqualTo(exceptedReceipt));
        }

        [Test]
        public void when_purchasing_scenario3()
        {
            //Input 3:
            //1 imported bottle of perfume at 27.99
            //1 bottle of perfume at 18.99
            //1 packet of headache pills at 9.75
            //1 box of imported chocolates at 11.25

            _shoppingBasket.AddToBasket(new Item { Category = Category.Perfume, Description = "bottle of perfume", IsImported = true, Price = 27.99m });
            _shoppingBasket.AddToBasket(new Item { Category = Category.Perfume, Description = "bottle of perfume", IsImported = false, Price = 18.99m });
            _shoppingBasket.AddToBasket(new Item { Category = Category.MedicalProduct, Description = "packet of headache pills", IsImported = false, Price = 9.75m });
            _shoppingBasket.AddToBasket(new Item { Category = Category.Food, Description = "box of chocolates", IsImported = true, Price = 11.25m });

            var receipt = _shoppingBasket.Purchase();

            var exceptedReceipt =
                "1 imported bottle of perfume: 32.19\r\n" +
                "1 bottle of perfume: 20.89\r\n" +
                "1 packet of headache pills: 9.75\r\n" +
                "1 imported box of chocolates: 11.85\r\n" +
                "Sales Taxes: 6.70\r\n" +
                "Total: 74.68\r\n";

            "It should generate the correct receipt".AssertThat(receipt, Is.EqualTo(exceptedReceipt));
        }
    }
}
