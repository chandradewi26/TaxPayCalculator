namespace TaxPayCalculator
{
    public class LmitoCalculator : ICalculator
    {
        public decimal Calculate(Resident resident)
        {
            var taxableIncome = resident.TaxableIncome;

            if (taxableIncome >= 0 && taxableIncome <= 37000)
                return 675;
            if (taxableIncome >= 37001 && taxableIncome <= 48000)
            {
                var lmito = 675 + ((taxableIncome - 37000) * 0.075m); 
                if (lmito > 1500)
                    lmito = 1500;
                return lmito;
            }
            if (taxableIncome >= 48000 && taxableIncome <= 90000)
                return 1500;
            if (taxableIncome >= 90001 && taxableIncome <= 126000)
            {
                return 1500 - ((taxableIncome - 90000) * 0.03m);
            }
            return 0;
        }
    }
}
