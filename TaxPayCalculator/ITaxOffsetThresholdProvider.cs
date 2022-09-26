namespace TaxPayCalculator
{
    public interface ITaxOffsetThresholdProvider
    {
        IList<TaxOffsetThreshold> CreateTaxOffsetThresholdTable(string type);
    }
}