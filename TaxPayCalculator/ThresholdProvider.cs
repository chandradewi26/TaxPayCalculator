namespace TaxPayCalculator
{    
    public class ThresholdProvider : IThresholdProvider
    {
        public IList<TaxThreshold> CreateTaxThresholdTable(int year)
        {
            var taxThresholdList = new List<TaxThreshold>();

            switch (year) 
            {
                case 2022: //2022-2023
                    taxThresholdList.Add(new TaxThreshold(0, 18200, 0m));
                    taxThresholdList.Add(new TaxThreshold(18200, 45000, 0.19m));
                    taxThresholdList.Add(new TaxThreshold(45000, 120000, 0.325m));
                    taxThresholdList.Add(new TaxThreshold(120000, 180000, 0.37m));
                    taxThresholdList.Add(new TaxThreshold(180000, decimal.MaxValue, 0.45m));
                    break;
                default: 
                    break;
            }
            return taxThresholdList;
        }
    }
}