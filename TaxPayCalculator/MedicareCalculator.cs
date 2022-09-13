namespace TaxPayCalculator
{
    public class MedicareCalculator : ICalculator
    {
        public decimal Calculate(Resident resident)
        {
            var taxableIncome = resident.TaxableIncome;

            return taxableIncome * 0.02m;
        }
    }
}
