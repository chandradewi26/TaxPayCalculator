namespace TaxPayCalculator
{
    public class LmitoCalculator : ICalculator
    {
        public decimal Calculate(Resident resident)
        {
            decimal taxOffsetOnThisRange = 0;
            var taxableIncome = resident.TaxableIncome;
            var lmitoThresholdList = ThresholdProvider.GetLmitoThreshold();

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
    }
}
