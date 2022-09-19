namespace TaxPayCalculator
{
    public class MedicareCalculator : ICalculator
    {
        public decimal Calculate(Resident resident)
        {
            return resident.TaxableIncome * 0.02m;
        }
    }
}
