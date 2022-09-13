using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /*
        [Fact(DisplayName = "Given income of $15,000 - $700 LITO tax offset will be applied")]
        [Fact(DisplayName = "Given income of $37,000 - $700 LITO tax offset will be applied")]
        [Fact(DisplayName = "Given income of $40,000 - $575 Vtax offset will be applied")]
        [Fact(DisplayName = "Given income of $45,000 - $325 LITO tax offset will be applied")]
        [Fact(DisplayName = "Given income of $55,000 - $175 LITO tax offset will be applied")]
        [Fact(DisplayName = "Given income more than $66,667 - $0 LITO tax offset will be applied")]
        */
    }
}
