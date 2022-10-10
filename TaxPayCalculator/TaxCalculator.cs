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
            //var taxThresholdList = _thresholdProvider.CreateTaxThresholdTable();
            var taxThresholdList = TaxCalculatorThreshold.GetTaxThresholdTable();

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

    public static class TaxCalculatorThreshold
    {
        public static IList<TaxThreshold> GetTaxThresholdTable()
        {
            var taxThresholdList = new List<TaxThreshold>();

            taxThresholdList.Add(new TaxThreshold(0, 18200, 0m));
            taxThresholdList.Add(new TaxThreshold(18200, 45000, 0.19m));
            taxThresholdList.Add(new TaxThreshold(45000, 120000, 0.325m));
            taxThresholdList.Add(new TaxThreshold(120000, 180000, 0.37m));
            taxThresholdList.Add(new TaxThreshold(180000, decimal.MaxValue, 0.45m));

            return taxThresholdList;
        }
    }
}
