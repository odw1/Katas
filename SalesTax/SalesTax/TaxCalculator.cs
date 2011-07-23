namespace SalesTax
{
    public interface ITaxCalculator
    {
        decimal CalculateTax(decimal price, Category category, bool itemImported);
    }

    public class TaxCalculator : ITaxCalculator
    {
        public decimal CalculateTax(decimal price, Category category, bool itemImported)
        {
            return 0;
        }
    }
}