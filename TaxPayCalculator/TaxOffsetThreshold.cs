namespace TaxPayCalculator
{
    public class TaxOffsetThreshold
    {
        public TaxOffsetThreshold(decimal lowerLimit, decimal upperLimit, decimal percentage, decimal offset)
        {
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
            Percentage = percentage;
            Offset = offset;
        }

        public decimal LowerLimit { get; }
        public decimal UpperLimit { get; }
        public decimal Percentage { get; }
        public decimal Offset { get; }
    }
}