namespace TaxPayCalculator.Tests
{
    public class MedicareCalculatorTests : CalculatorTestsFixture
    {
        protected override ICalculator CreateCalculator()
        {
            return new MedicareCalculator();
        }

        protected override Resident CreateResident(decimal taxableincome)
        {
            return new Resident(taxableincome);
        }

        [Fact(DisplayName = "Given income, resident will receive Correct amount of tax offset")]
        public void TestCalculateMedicare_GivenIncome_ShouldReturnCorrectAmountOfTaxOffset()
        {
            var random = new Random();
            var taxableIncome = random.Next(0, int.MaxValue);
            decimal taxOffset = taxableIncome*0.02m;
            TestCalculation(taxableIncome, taxOffset);
        }
    }
}

/*
        [Theory(DisplayName = "Given income, MedicareCalculator should calculate the correct medicare levy amount")]
        [InlineData(15000, 300)]
        [InlineData(37000, 740)]
        [InlineData(40000, 800)]
        [InlineData(45000, 900)]
        [InlineData(55000, 1100)]
        [InlineData(70000, 1400)]
        [InlineData(92000, 1840)]
        [InlineData(120000, 2400)]
        [InlineData(150000, 3000)]
        [InlineData(180000, 3600)]
        [InlineData(200000, 4000)]
        public void TestCalculateMedicare_GivenIncome_ReturnCorrectAmount(decimal input, decimal expectedOutput)
        {
            TestCalculation(input, expectedOutput);
        }
*/
