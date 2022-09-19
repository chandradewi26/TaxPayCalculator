namespace TaxPayCalculator
{
    public class TaxCalculator : ICalculator
    {
        public decimal Calculate(Resident resident)
        {
            var taxableIncome = resident.TaxableIncome;

            if (taxableIncome >= 0 && taxableIncome <= 18200)
                return 0;
            if (taxableIncome >= 18201 && taxableIncome <= 45000)
                return (taxableIncome - 18200) * 0.19m;
            if (taxableIncome >= 45001 && taxableIncome <= 120000)
                return 5092 + ((taxableIncome - 45000) * 0.325m);
            if (taxableIncome >= 120001 && taxableIncome <= 180000)
                return 29467 + ((taxableIncome - 120000) * 0.37m);
            if (taxableIncome >= 180001)
                return 51667 + ((taxableIncome - 180000) * 0.45m);
            return 0;
        }
    }
}
