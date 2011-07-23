using System;
using System.Collections.Generic;

namespace SalesTax
{
    public interface ITaxCalculator
    {
        decimal Calculate(decimal price, Category category, bool itemImported);
    }

    public class TaxCalculator : ITaxCalculator
    {
        private static readonly List<Category> TaxExemptGoods;

        public decimal Calculate(decimal price, Category category, bool itemImported)
        {
            var salesTax = 0m;
            var importDuty = 0m;

            if (!TaxExemptGoods.Contains(category))
            {
                salesTax = price*0.1m;
            }

            if (itemImported)
            {
                importDuty = price*0.05m;
            }

            var totalTaxes = salesTax + importDuty;

            return Math.Ceiling(totalTaxes*20)/20;
        }

        static TaxCalculator()
        {
            TaxExemptGoods = new List<Category> {Category.Book, Category.Food, Category.MedicalProduct};
        }
    }
}