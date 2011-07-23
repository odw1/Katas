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
        [Test]
        public void when_purchasing_scenario1()
        {
            //Input 1:
            //1 book at 12.49
            //1 music CD at 14.99
            //1 chocolate bar at 0.85
            //Output 1:
            //1 book: 12.49
            //1 music CD: 16.49
            //1 chocolate bar: 0.85
            //Sales Taxes: 1.50
            //Total: 29.83
            Assert.Fail();
        }

        [Test]
        public void when_purchasing_scenario2()
        {
            //Input 2:
            //1 imported box of chocolates at 10.00
            //1 imported bottle of perfume at 47.50
            //Output 2:
            //1 imported box of chocolates: 10.50
            //1 imported bottle of perfume: 54.65
            //Sales Taxes: 7.65
            //Total: 65.15
            Assert.Fail();
        }

        [Test]
        public void when_purchasing_scenario3()
        {
            //Input 3:
            //1 imported bottle of perfume at 27.99
            //1 bottle of perfume at 18.99
            //1 packet of headache pills at 9.75
            //1 box of imported chocolates at 11.25
            //Output 3:
            //1 imported bottle of perfume: 32.19
            //1 bottle of perfume: 20.89
            //1 packet of headache pills: 9.75
            //1 imported box of chocolates: 11.85
            //Sales Taxes: 6.70
            //Total: 74.68
            Assert.Fail();
        }
    }
}
