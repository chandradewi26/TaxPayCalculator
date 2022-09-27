namespace TaxPayCalculator
{
    public class LmitoThresholdProvider : ITaxOffsetThresholdProvider
    {
        public IList<TaxOffsetThreshold> CreateTaxOffsetThresholdTable()
        {
            var lmitoThresholdList = new List<TaxOffsetThreshold>();

            lmitoThresholdList.Add(new TaxOffsetThreshold(0, 37000, 0m, 675));
            lmitoThresholdList.Add(new TaxOffsetThreshold(37000, 48000, 0.075m, 675));
            lmitoThresholdList.Add(new TaxOffsetThreshold(48000, 90000, 0m, 1500));
            lmitoThresholdList.Add(new TaxOffsetThreshold(90000, 126000, 0.03m, 1500));

            return lmitoThresholdList;
        }
    }
}