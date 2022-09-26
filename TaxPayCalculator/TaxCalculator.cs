namespace TaxPayCalculator
{
    public class TaxCalculator : ICalculator
    {
        public TaxCalculator() : this(new TaxThresholdProvider())
        {

        }
        
        public TaxCalculator(ITaxThresholdProvider thresholdProvider)
        {
            _thresholdProvider = thresholdProvider;
        }

        public decimal Calculate(Resident resident)
        {
            decimal taxOnThisRange = 0;
            var taxableIncome = resident.TaxableIncome;
            var taxThresholdList = _thresholdProvider.CreateTaxThresholdTable();

            for (int i = 0; i < taxThresholdList.Count(); i++)
            {
                var lowerLimit = taxThresholdList[i].LowerLimit;
                var upperLimit = taxThresholdList[i].UpperLimit;
                var percentage = taxThresholdList[i].Percentage;

                if (taxableIncome > lowerLimit && taxableIncome <= upperLimit)
                    taxOnThisRange += (taxableIncome - lowerLimit) * percentage;

                if (taxableIncome > upperLimit)
                    taxOnThisRange += (upperLimit - lowerLimit) * percentage;
            }

            return taxOnThisRange;
        }
    
        private readonly ITaxThresholdProvider _thresholdProvider;
    }
}
