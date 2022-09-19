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
    }
}
