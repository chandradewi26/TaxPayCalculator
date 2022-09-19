namespace TaxPayCalculator.Tests
{
    public class LitoCalculatorTests : CalculatorTestsFixture
    {
        protected override ICalculator CreateCalculator()
        {
            return new LitoCalculator();
        }

        protected override Resident CreateResident(decimal taxableincome)
        {
            return new Resident(taxableincome);
        }

        [Fact(DisplayName = "Given range of income $0 ~ $37500, resident will receive $700 tax offset")]
        public void TestCalculateLito_GivenIncome0to37500_ShouldReturn700TaxOffset()
        {
            var random = new Random();
            var taxableIncome = random.Next(0, 37501);
            var taxOffset = 700;
            TestCalculation(taxableIncome, taxOffset);
        }

        [Fact(DisplayName = "Given range of income $37501 ~ $45000, resident will receive correct ammount of tax offset")]
        public void TestCalculateLito_GivenIncome37501to45000_ShouldReturnCorrectAmountOfTaxOffset()
        {
            var random = new Random();
            var taxableIncome = random.Next(37501, 45001);
            decimal taxOffset = 700 - ((taxableIncome - 37500) * 0.05m);
            TestCalculation(taxableIncome, taxOffset);
        }
        
        [Fact(DisplayName = "Given range of income $45001 ~ $66667, resident will receive correct ammount of tax offset")]
        public void TestCalculateLito_GivenIncome45001to66667_ShouldReturnCorrectAmountOfTaxOffset()
        {
            var random = new Random();
            var taxableIncome = random.Next(45001, 66668);
            decimal taxOffset = 325 - ((taxableIncome - 45000) * 0.015m);
            TestCalculation(taxableIncome, taxOffset);
        }
                
        [Fact(DisplayName = "Given income more than $66667, resident will receive $0 tax offset")]
        public void TestCalculateLito_GivenIncomeMoreThan66667_ShouldReturn0TaxOffset()
        {
            var random = new Random();
            var taxableIncome = random.Next(66668, int.MaxValue);
            decimal taxOffset = 0;
            TestCalculation(taxableIncome, taxOffset);
        }
    }
}
    /*
        [Theory(DisplayName = "Given income, LitoCalculator should calculate the correct tax offset amount")]
        [InlineData(-100, 0)]
        [InlineData(15000, 700)]
        [InlineData(37000, 700)]
        [InlineData(40000, 575)]
        [InlineData(45000, 325)]
        [InlineData(50000, 250)]
        [InlineData(55000, 175)]
        [InlineData(70000, 0)] 
        public void TestCalculateLito_GivenIncome_ReturnCorrectAmount(decimal input, decimal expectedOutput)
        {
            TestCalculation(input, expectedOutput);
        }
    */