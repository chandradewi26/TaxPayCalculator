namespace TaxPayCalculator
{
    public interface ITaxThresholdProvider
    {
        IList<TaxThreshold> CreateTaxThresholdTable();
    }
}