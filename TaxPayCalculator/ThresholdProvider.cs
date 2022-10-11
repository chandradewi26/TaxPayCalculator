namespace TaxPayCalculator
{    
    public static class ThresholdProvider
    {        
        public static IList<TaxThreshold> GetTaxThreshold()
        {
            var taxThresholdList = new List<TaxThreshold>();

            taxThresholdList.Add(new TaxThreshold(0, 18200, 0m));
            taxThresholdList.Add(new TaxThreshold(18200, 45000, 0.19m));
            taxThresholdList.Add(new TaxThreshold(45000, 120000, 0.325m));
            taxThresholdList.Add(new TaxThreshold(120000, 180000, 0.37m));
            taxThresholdList.Add(new TaxThreshold(180000, decimal.MaxValue, 0.45m));

            return taxThresholdList;
        }
        public static IList<TaxOffsetThreshold> GetLitoThreshold()
        {
            var litoThresholdList = new List<TaxOffsetThreshold>();

            litoThresholdList.Add(new TaxOffsetThreshold(0, 37500, 0m, 700));
            litoThresholdList.Add(new TaxOffsetThreshold(37500, 45000, 0.05m, 700));
            litoThresholdList.Add(new TaxOffsetThreshold(45000, 66667, 0.015m, 325));

            return litoThresholdList;
        }

        public static IList<TaxOffsetThreshold> GetLmitoThreshold()
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