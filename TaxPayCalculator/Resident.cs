namespace TaxPayCalculator
{
    public class Resident
    {
        public Resident(decimal taxableIncome)
        {
            TaxableIncome = taxableIncome;
        }
        
        public decimal TaxableIncome { get; }
    }
}
