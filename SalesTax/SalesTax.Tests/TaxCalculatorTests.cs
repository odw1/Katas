using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SalesTax.Tests
{
    [TestFixture]
    public class TaxCalculatorTests
    {
        [Test]
        [TestCase(Category.Book)]
        [TestCase(Category.Food)]
        [TestCase(Category.MedicalProduct)]
        public void when_calculating_tax_exempt_goods(Category category)
        {
            var taxCalculator = new TaxCalculator();

            var salesTax = taxCalculator.Calculate(10m, category, false);

            "It should calculate no sales".AssertThat(salesTax, Is.EqualTo(0m));
        }

        [Test]
        [TestCase(Category.Perfume)]
        [TestCase(Category.MusicCD)]
        public void when_calculating_tax_non_exempt_goods(Category category)
        {
            var taxCalculator = new TaxCalculator();

            var salesTax = taxCalculator.Calculate(10m, category, false);

            "It should calculate no sales".AssertThat(salesTax, Is.EqualTo(1m));
        }

        [Test]
        [TestCase(Category.Book)]
        [TestCase(Category.Food)]
        [TestCase(Category.MedicalProduct)]
        public void when_calculating_tax_for_imported_exempt_goods(Category category)
        {
            var taxCalculator = new TaxCalculator();

            var salesTax = taxCalculator.Calculate(10m, category, true);

            "It should calculate no sales".AssertThat(salesTax, Is.EqualTo(0.5m));
        }

        [Test]
        [TestCase(Category.Perfume)]
        [TestCase(Category.MusicCD)]
        public void when_calculating_tax_for_imported_non_exempt_goods(Category category)
        {
            var taxCalculator = new TaxCalculator();

            var salesTax = taxCalculator.Calculate(10m, category, true);

            "It should calculate no sales".AssertThat(salesTax, Is.EqualTo(1.5m));
        }

        [Test]
        public void when_calculating_tax_and_rounding_is_required()
        {
            var taxCalculator = new TaxCalculator();

            var salesTax = taxCalculator.Calculate(11.25m, Category.Food, true);

            "It should round the tax correctly".AssertThat(salesTax, Is.EqualTo(0.6m));

        }

        [Test]
        public void ensure_all_categories_tested()
        {
            int length = Enum.GetValues(typeof (Category)).Length;

            "It should have 5 values".AssertThat(length, Is.EqualTo(5));
        }
    }
}
