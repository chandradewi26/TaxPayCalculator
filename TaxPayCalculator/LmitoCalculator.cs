namespace TaxPayCalculator
{
    public class LmitoCalculator : ICalculator
    {
        public LmitoCalculator() : this(new LmitoThresholdProvider())
        {

        }

         public LmitoCalculator(ITaxOffsetThresholdProvider thresholdProvider)
        {
            _thresholdProvider = thresholdProvider;
        }

        public decimal Calculate(Resident resident)
        {
            decimal taxOffsetOnThisRange = 0;
            var taxableIncome = resident.TaxableIncome;
            //var lmitoThresholdList = _thresholdProvider.CreateTaxOffsetThresholdTable();
            var lmitoThresholdList = LmitoCalculatorThreshold.GetTaxOffsetThresholdTable();

            for (int i = 0 ; i < lmitoThresholdList.Count(); i++)
            {
                var lowerLimit = lmitoThresholdList[i].LowerLimit;
                var upperLimit = lmitoThresholdList[i].UpperLimit;
                var percentage = lmitoThresholdList[i].Percentage;
                var offset = lmitoThresholdList[i].Offset;

                //For all range of income below $90000
                if (taxableIncome > lowerLimit && taxableIncome <= upperLimit && taxableIncome <= 90000)
                    taxOffsetOnThisRange = offset + (taxableIncome - lowerLimit) * percentage;

                //For all range of income above $90000
                if (taxableIncome > lowerLimit && taxableIncome <= upperLimit && taxableIncome > 90000)
                    taxOffsetOnThisRange = offset - (taxableIncome - lowerLimit) * percentage;
            }

            return taxOffsetOnThisRange;
        }
        
        private readonly ITaxOffsetThresholdProvider _thresholdProvider;
    }

    public static class LmitoCalculatorThreshold
    {
        public static IList<TaxOffsetThreshold> GetTaxOffsetThresholdTable()
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
