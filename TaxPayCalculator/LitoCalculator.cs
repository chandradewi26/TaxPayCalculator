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
            var litoThresholdList = _thresholdProvider.CreateTaxOffsetThresholdTable();

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
}
