namespace TaxPayCalculator.Tests
{
    public abstract class CalculatorTestsFixture
    {
        private ICalculator? _calculator;
        protected abstract ICalculator CreateCalculator();

        protected abstract Resident CreateResident(decimal taxableincome);

        public void TestCalculation(decimal input, decimal expectedOutput)
        {
            _calculator = CreateCalculator();
            var resident = CreateResident(input);
            var result = _calculator.Calculate(resident);
            Assert.Equal(expectedOutput, result);
        }
    }
}