using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SalesTax.Tests
{
    [TestFixture]
    public class ReceiptBuilderTests
    {
        [Test]
        public void when_building_with_a_purchased_item()
        {
            var receiptBuilder = new ReceiptBuilder();

            var receipt = receiptBuilder
                .WithPurchasedItem("book", false, 15.55m)
                .WithPurchasedItem("fridge", false, 7m)
                .Build();

            var expectedReceipt =
                "1 book: 15.55\r\n" +
                "1 fridge: 7.00\r\n" +
                "Sales Taxes: 0.00\r\n" +
                "Total: 0.00\r\n";

            "It should generate the receipt".AssertThat(receipt, Is.EqualTo(expectedReceipt));
        }

        [Test]
        public void when_building_with_an_imported_purchased_item()
        {
            var receiptBuilder = new ReceiptBuilder();

            var receipt = receiptBuilder
                .WithPurchasedItem("book", true, 15.55m)
                .WithPurchasedItem("fridge", true, 8.5m)
                .Build();

            var expectedReceipt =
                "1 imported book: 15.55\r\n" +
                "1 imported fridge: 8.50\r\n" +
                "Sales Taxes: 0.00\r\n" +
                "Total: 0.00\r\n";

            "It should generate the receipt".AssertThat(receipt, Is.EqualTo(expectedReceipt));
        }

        [Test]
        public void when_building_with_sales_taxes()
        {
            var receiptBuilder = new ReceiptBuilder();

            var receipt = receiptBuilder
                .WithSalesTaxes(16.43m)
                .Build();

            var expectedReceipt =
                "Sales Taxes: 16.43\r\n" +
                "Total: 0.00\r\n";

            "It should generate the receipt".AssertThat(receipt, Is.EqualTo(expectedReceipt));
        }

        [Test]
        public void when_building_with_sales_taxes_with_less_than_2_decimal_places()
        {
            var receiptBuilder = new ReceiptBuilder();

            var receipt = receiptBuilder
                .WithSalesTaxes(16.4m)
                .Build();

            var expectedReceipt =
                "Sales Taxes: 16.40\r\n" +
                "Total: 0.00\r\n";

            "It should generate the receipt".AssertThat(receipt, Is.EqualTo(expectedReceipt));
        }

        [Test]
        public void when_building_with_total_price()
        {
            var receiptBuilder = new ReceiptBuilder();

            var receipt = receiptBuilder
                .WithTotalPrice(16.43m)
                .Build();

            var expectedReceipt =
                "Sales Taxes: 0.00\r\n" +
                "Total: 16.43\r\n";

            "It should generate the receipt".AssertThat(receipt, Is.EqualTo(expectedReceipt));
        }

        [Test]
        public void when_building_with_total_price_with_less_than_2_decimal_places()
        {
            var receiptBuilder = new ReceiptBuilder();

            var receipt = receiptBuilder
                .WithTotalPrice(16m)
                .Build();

            var expectedReceipt =
                "Sales Taxes: 0.00\r\n" +
                "Total: 16.00\r\n";

            "It should generate the receipt".AssertThat(receipt, Is.EqualTo(expectedReceipt));
        }

        [Test]
        public void when_building_with_everything()
        {
            var receiptBuilder = new ReceiptBuilder();

            var receipt = receiptBuilder
                .WithPurchasedItem("book", false, 15.55m)
                .WithPurchasedItem("box of chocolates", true, 7.99m)
                .WithSalesTaxes(12.34m)
                .WithTotalPrice(123.77m)
                .Build();

            var expectedReceipt =
                "1 book: 15.55\r\n" +
                "1 imported box of chocolates: 7.99\r\n" +
                "Sales Taxes: 12.34\r\n" +
                "Total: 123.77\r\n";

            "It should generate the receipt".AssertThat(receipt, Is.EqualTo(expectedReceipt));
        }
    }
}
