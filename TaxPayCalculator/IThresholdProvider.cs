
namespace TaxPayCalculator
{
    public interface IThresholdProvider
    {
        IList<TaxThreshold> CreateTaxThresholdTable();
    }
}