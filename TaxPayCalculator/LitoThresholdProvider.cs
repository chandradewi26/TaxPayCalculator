namespace TaxPayCalculator
{
    public class LitoThresholdProvider : ITaxOffsetThresholdProvider
    {
        public IList<TaxOffsetThreshold> CreateTaxOffsetThresholdTable()
        {
            var litoThresholdList = new List<TaxOffsetThreshold>();

            litoThresholdList.Add(new TaxOffsetThreshold(0, 37500, 0m, 700));
            litoThresholdList.Add(new TaxOffsetThreshold(37500, 45000, 0.05m, 700));
            litoThresholdList.Add(new TaxOffsetThreshold(45000, 66667, 0.015m, 325));

            return litoThresholdList;
        }
    }
}