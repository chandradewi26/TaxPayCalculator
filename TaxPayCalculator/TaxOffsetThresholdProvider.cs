namespace TaxPayCalculator
{    
    public class TaxOffsetThresholdProvider : ITaxOffsetThresholdProvider
    {
        public IList<TaxOffsetThreshold> CreateTaxOffsetThresholdTable(string type)
        {
            var taxOffsetThresholdList = new List<TaxOffsetThreshold>();

            if (type == "lito")
            {
                taxOffsetThresholdList.Add(new TaxOffsetThreshold(0, 37500, 0m, 700));
                taxOffsetThresholdList.Add(new TaxOffsetThreshold(37500, 45000, 0.05m, 700));
                taxOffsetThresholdList.Add(new TaxOffsetThreshold(45000, 66667, 0.015m, 325));
                
            }

            if (type == "lmito")
            {
                taxOffsetThresholdList.Add(new TaxOffsetThreshold(0, 37000, 0m, 675));
                taxOffsetThresholdList.Add(new TaxOffsetThreshold(37000, 48000, 0.075m, 675)); //Maximum amount = 1500
                taxOffsetThresholdList.Add(new TaxOffsetThreshold(48000, 90000, 0m, 1500));
                taxOffsetThresholdList.Add(new TaxOffsetThreshold(90000, 126000, 0.03m, 1500));
            }

            return taxOffsetThresholdList;
        }
    }
}