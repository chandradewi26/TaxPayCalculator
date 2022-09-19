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

        [Theory(DisplayName = "Given income, LitoCalculator should calculate the correct tax offset amount")]
        [InlineData(-100, 0)]
        [InlineData(15000, 700)]
        [InlineData(37000, 700)]
        [InlineData(40000, 575)]
        [InlineData(45000, 325)]
        [InlineData(50000, 250)]
        [InlineData(55000, 175)]
        [InlineData(70000, 0)] /*Not Eligible*/
        public void TestCalculateLito_GivenIncome_ReturnCorrectAmount(decimal input, decimal expectedOutput)
        {
            TestCalculation(input, expectedOutput);
        }
    }
}
