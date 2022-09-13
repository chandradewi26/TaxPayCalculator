namespace TaxPayCalculator
{
    public class Resident
    {
        public decimal TaxableIncome { get; }
        //public string IncomeYear { get; }
        //public decimal Tax { get; }
        //public decimal TaxOffset { get; }
        //public bool TaxThreshold { get; }

        public Resident(decimal taxableIncome)
        {
            TaxableIncome = taxableIncome;
        }
    }
}
