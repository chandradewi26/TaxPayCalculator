namespace TaxPayCalculator.Tests
{
    public class TaxCalculatorTests : CalculatorTestsFixture
    {
        protected override ICalculator CreateCalculator()
        {
            return new TaxCalculator();
        }

        protected override Resident CreateResident(decimal taxableincome)
        {
            return new Resident(taxableincome);
        }

        [Fact(DisplayName = "Given range of income $0 ~ $18200, resident will receive the correct amount of tax offset")]
        public void TestCalculateTax_GivenIncome0to18200_ShouldReturnCorrectAmountOfTaxOffset()
        {
            var random = new Random();
            var taxableIncome = random.Next(0, 18201);
            var taxOnThisRange = 0.0m;

            var lowerLimit = 0;
            var upperLimit = 18200;
            var percentage = 0.0m;

            if (taxableIncome > lowerLimit && taxableIncome <= upperLimit)
                taxOnThisRange = taxOnThisRange + (taxableIncome - lowerLimit) * percentage;

            taxOnThisRange += 0;

            TestCalculation(taxableIncome, taxOnThisRange);
        }
        
        [Fact(DisplayName = "Given range of income $18201 ~ $45000, resident will receive the correct amount of tax offset")]
        public void TestCalculateTax_GivenIncome18201to45000_ShouldReturnCorrectAmountOfTaxOffset()
        {
            var random = new Random();
            var taxableIncome = random.Next(18201, 45001);
            var taxOnThisRange = 0.0m;

            var lowerLimit = 18200;
            var upperLimit = 45000;
            var percentage = 0.19m;

            if (taxableIncome > lowerLimit && taxableIncome <= upperLimit)
                taxOnThisRange = taxOnThisRange + (taxableIncome - lowerLimit) * percentage;

            taxOnThisRange += 0;

            TestCalculation(taxableIncome, taxOnThisRange);
        }
                
        [Fact(DisplayName = "Given range of income $45001 ~ $120000, resident will receive the correct amount of tax offset")]
        public void TestCalculateTax_GivenIncome45001to120000_ShouldReturnCorrectAmountOfTaxOffset()
        {
            var random = new Random();
            var taxableIncome = random.Next(45001, 120001);
            var taxOnThisRange = 0.0m;

            var lowerLimit = 45000;
            var upperLimit = 120000;
            var percentage = 0.325m;

            if (taxableIncome > lowerLimit && taxableIncome <= upperLimit)
                taxOnThisRange = taxOnThisRange + (taxableIncome - lowerLimit) * percentage;

            if (taxableIncome > upperLimit)
                taxOnThisRange += (upperLimit - lowerLimit) * percentage;

            taxOnThisRange += 5092;

            TestCalculation(taxableIncome, taxOnThisRange);
        }
                        
        [Fact(DisplayName = "Given range of income $120001 ~ $180000, resident will receive the correct amount of tax offset")]
        public void TestCalculateTax_GivenIncome120001to180000_ShouldReturnCorrectAmountOfTaxOffset()
        {
            var random = new Random();
            var taxableIncome = random.Next(120001, 180001);
            var taxOnThisRange = 0.0m;

            var lowerLimit = 120000;
            var upperLimit = 180000;
            var percentage = 0.37m;

            if (taxableIncome > lowerLimit && taxableIncome <= upperLimit)
                taxOnThisRange = taxOnThisRange + (taxableIncome - lowerLimit) * percentage;

            if (taxableIncome > upperLimit)
                taxOnThisRange += (upperLimit - lowerLimit) * percentage;

            taxOnThisRange += 5092 + 24375;

            TestCalculation(taxableIncome, taxOnThisRange);
        }
                                
        [Fact(DisplayName = "Given range of income more than $180000, resident will receive the correct amount of tax offset")]
        public void TestCalculateTax_GivenIncomeMoreThan180000_ShouldReturnCorrectAmountOfTaxOffset()
        {
            var random = new Random();
            var taxableIncome = random.Next(180001, int.MaxValue);
            var taxOnThisRange = 0.0m;

            var lowerLimit = 180000;
            var upperLimit = int.MaxValue;
            var percentage = 0.45m;

            taxableIncome = 200000;

            if (taxableIncome > lowerLimit && taxableIncome <= upperLimit)
                taxOnThisRange = taxOnThisRange + (taxableIncome - lowerLimit) * percentage;

            if (taxableIncome > upperLimit)
                taxOnThisRange += (upperLimit - lowerLimit) * percentage;

            taxOnThisRange += 5092 + 24375 + 22200;

            TestCalculation(taxableIncome, taxOnThisRange);
        }
    }
}

/*
        [Theory(DisplayName = "Given income, TaxCalculator should calculate the correct tax amount")]
        [InlineData(15000, 0)]
        [InlineData(37000, 3572)]
        [InlineData(40000, 4142)]
        [InlineData(45000, 5092)]
        [InlineData(55000, 8342)]
        [InlineData(70000, 13217)]
        [InlineData(92000, 20367)]
        [InlineData(120000, 29467)]
        [InlineData(150000, 40567)]
        [InlineData(180000, 51667)]
        [InlineData(200000, 60667)]
        public void TestCalculateTax_GivenIncome_ReturnCorrectAmount(decimal input, decimal expectedOutput)
        {
            TestCalculation(input, expectedOutput);
        }
*/