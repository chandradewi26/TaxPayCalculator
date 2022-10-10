namespace TaxPayCalculator
{
    public class LitoCalculator : ICalculator
    {
        public LitoCalculator() : this(new LitoThresholdProvider())
        {

        }

        public LitoCalculator(ITaxOffsetThresholdProvider thresholdProvider)
        {
            _thresholdProvider = thresholdProvider;
        }

        public decimal Calculate(Resident resident)
        {
            decimal taxOffsetOnThisRange = 0;
            var taxableIncome = resident.TaxableIncome;
            //var litoThresholdList = _thresholdProvider.CreateTaxOffsetThresholdTable();
            var litoThresholdList = LitoCalculatorThreshold.GetTaxOffsetThresholdTable();

            for (int i = 0; i < litoThresholdList.Count(); i++)
            {
                var lowerLimit = litoThresholdList[i].LowerLimit;
                var upperLimit = litoThresholdList[i].UpperLimit;
                var percentage = litoThresholdList[i].Percentage;
                var offset = litoThresholdList[i].Offset;

                if (taxableIncome > lowerLimit && taxableIncome <= upperLimit)
                    taxOffsetOnThisRange = offset - (taxableIncome - lowerLimit) * percentage;
            }

            return taxOffsetOnThisRange;
        }
        
        private readonly ITaxOffsetThresholdProvider _thresholdProvider;
    }

    public static class LitoCalculatorThreshold
    {
        public static IList<TaxOffsetThreshold> GetTaxOffsetThresholdTable()
        {
            var litoThresholdList = new List<TaxOffsetThreshold>();

            litoThresholdList.Add(new TaxOffsetThreshold(0, 37500, 0m, 700));
            litoThresholdList.Add(new TaxOffsetThreshold(37500, 45000, 0.05m, 700));
            litoThresholdList.Add(new TaxOffsetThreshold(45000, 66667, 0.015m, 325));

            return litoThresholdList;
        }
    }
}
