namespace TaxPayCalculator
{
    public class Resident
    {
        public decimal TaxableIncome { get; }

        public Resident(decimal taxableIncome)
        {
            TaxableIncome = taxableIncome;
        }
    }
}
