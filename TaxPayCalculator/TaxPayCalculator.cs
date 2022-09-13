namespace TaxPayCalculator
{
    /*Calculate tax + offset + medicare*/
    public class TaxPayCalculator : ICalculator
    {
        public decimal Calculate(Resident resident)
        {

            decimal GetCalculatedTax<TCalculator>()
                where TCalculator : ICalculator, new()
            {
                return this.CalculateAmount<TCalculator>(resident);
            }

            var tax = GetCalculatedTax<TaxCalculator>();
            var medicare = GetCalculatedTax<MedicareCalculator>();
            var lito = GetCalculatedTax<LitoCalculator>();
            var lmito = GetCalculatedTax<LmitoCalculator>();
            var taxPayable = tax + medicare - lito - lmito;

            if (taxPayable < 0)
                return 0;

            return taxPayable;
        }

        private decimal CalculateAmount<TCalculator>(Resident resident)
            where TCalculator : ICalculator, new()
        {
            var calculator = new TCalculator();
            return calculator.Calculate(resident);
        }
    }
}
