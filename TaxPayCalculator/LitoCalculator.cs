namespace TaxPayCalculator
{
    public class LitoCalculator : ICalculator
    {
        public decimal Calculate(Resident resident)
        {
            decimal taxOffsetOnThisRange = 0;
            var taxableIncome = resident.TaxableIncome;
            var litoThresholdList = ThresholdProvider.GetLitoThreshold();

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
    }
}
