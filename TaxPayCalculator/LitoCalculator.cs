namespace TaxPayCalculator
{
    public class LitoCalculator : ICalculator
    {
        public decimal Calculate(Resident resident)
        {
            var taxableIncome = resident.TaxableIncome;

            if (taxableIncome >= 0 && taxableIncome <= 37500)
                return 700;
            if (taxableIncome >= 37501 && taxableIncome <= 45000)
                return 700 - ((taxableIncome - 37500) * 0.05m);
            if (taxableIncome >= 45001 && taxableIncome <= 66667)
                return 325 - ((taxableIncome - 45000) * 0.015m);
            return 0;
        }
    }
}
