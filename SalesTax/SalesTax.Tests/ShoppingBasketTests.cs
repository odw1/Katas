using System;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;

namespace SalesTax.Tests
{
    [TestFixture]
    public class ShoppingBasketTests
    {
        [Test]
        public void when_purchasing_the_items_in_the_shopping_basket()
        {
            var book = new Item { Description = "book", Category = Category.Book, Price = 12.49m, IsImported = false };
            var cd = new Item { Description = "music CD", Category = Category.MusicCD, Price = 14.99m, IsImported = true };
            string receiptText = "a receipt";

            var taxCalculator = MockRepository.GenerateStub<ITaxCalculator>();
            var receiptBuilder = MockRepository.GenerateStub<IReceiptBuilder>();

            taxCalculator.Stub(x => x.Calculate(book.Price, book.Category, book.IsImported)).Return(0m);
            taxCalculator.Stub(x => x.Calculate(cd.Price, cd.Category, cd.IsImported)).Return(2.54m);

            receiptBuilder.Stub(x => x.WithPurchasedItem(book.Description, book.IsImported, 12.49m)).Return(receiptBuilder);
            receiptBuilder.Stub(x => x.WithPurchasedItem(cd.Description, cd.IsImported, 17.53m)).Return(receiptBuilder);
            receiptBuilder.Stub(x => x.WithSalesTaxes(2.54m)).Return(receiptBuilder);
            receiptBuilder.Stub(x => x.WithTotalPrice(30.02m)).Return(receiptBuilder);
            receiptBuilder.Stub(x => x.Build()).Return(receiptText);

            var shoppingBasket = new ShoppingBasket(taxCalculator, receiptBuilder);
            shoppingBasket.AddToBasket(book);
            shoppingBasket.AddToBasket(cd);

            var receipt = shoppingBasket.Purchase();

            "It shoud call the builder with book".AssertWasCalled(receiptBuilder, x => x.WithPurchasedItem(book.Description, book.IsImported, 12.49m));
            "It should call the builder with the cd".AssertWasCalled(receiptBuilder, x => x.WithPurchasedItem(cd.Description, cd.IsImported, 17.53m));

            "It should return the receipt".AssertThat(receipt, Is.EqualTo(receiptText));

        }
    }
}
