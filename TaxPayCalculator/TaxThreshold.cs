namespace TaxPayCalculator
{
    public class TaxThreshold
    {
        public decimal LowerLimit {get;}
        public decimal UpperLimit {get;}
        public decimal Percentage {get;}

        public TaxThreshold(decimal lowerLimit, decimal upperLimit, decimal percentage)
        {
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
            Percentage = percentage;
        }
    }
}