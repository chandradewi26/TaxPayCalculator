namespace TaxPayCalculator.Tests
{
    public class LmitoCalculatorTests : CalculatorTestsFixture
    {

        protected override ICalculator CreateCalculator()
        {
            return new LmitoCalculator();
        }

        protected override Resident CreateResident(decimal taxableincome)
        {
            return new Resident(taxableincome);
        }

        [Fact(DisplayName = "Given range of income $0 ~ $37000, resident will receive $675 tax offset")]
        public void TestCalculateLito_GivenIncome0to37000_ShouldReturn675TaxOffset()
        {
            var random = new Random();
            var taxableIncome = random.Next(0, 37001);
            decimal taxOffset = 675;
            TestCalculation(taxableIncome, taxOffset);
        }

        [Fact(DisplayName = "Given range of income $37001 ~ $48000, resident will receive the correct amount of tax offset")]
        public void TestCalculateLito_GivenIncome37001to48000_ShouldReturnCorrectAmountOfTaxOffset()
        {
            var random = new Random();
            var taxableIncome = random.Next(37001, 48001);
            decimal taxOffset = 675 + ((taxableIncome - 37000) * 0.075m);
            if(taxOffset > 1500)
                taxOffset = 1500;
            TestCalculation(taxableIncome, taxOffset);
        }
        
        [Fact(DisplayName = "Given range of income $48001 ~ $90000, resident will receive $1500 tax offset")]
        public void TestCalculateLito_GivenIncome48001to90000_ShouldReturn1500TaxOffset()
        {
            var random = new Random();
            var taxableIncome = random.Next(48001, 90001);
            decimal taxOffset = 1500;
            TestCalculation(taxableIncome, taxOffset);
        }
        
        [Fact(DisplayName = "Given range of income $90001 ~ $126000, resident will receive the correct amount of tax offset")]
        public void TestCalculateLito_GivenIncome90001to126000_ShouldReturnCorrectAmountOfTaxOffset()
        {
            var random = new Random();
            var taxableIncome = random.Next(90001, 126001);
            decimal taxOffset = 1500 - ((taxableIncome - 90000) * 0.03m);
            TestCalculation(taxableIncome, taxOffset);
        }
    }
}

/*
        [Theory(DisplayName = "Given income, TaxCalculator should calculate the correct tax amount")]
        [InlineData(15000, 675)]
        [InlineData(37000, 675)]
        [InlineData(40000, 900)]
        [InlineData(45000, 1275)]
        [InlineData(55000, 1500)]
        [InlineData(70000, 1500)]
        [InlineData(92000, 1440)]
        [InlineData(120000, 600)]
        [InlineData(130000, 0)]
        public void TestCalculateLmito_GivenIncome_ReturnCorrectAmount(decimal input, decimal expectedOutput)
        {
            TestCalculation(input, expectedOutput);
        }
*/