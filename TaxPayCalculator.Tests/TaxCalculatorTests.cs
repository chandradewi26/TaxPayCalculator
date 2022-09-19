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
    }
}
