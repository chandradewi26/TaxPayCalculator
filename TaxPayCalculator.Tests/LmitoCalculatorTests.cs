using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /*
        [Fact(DisplayName = "Given income of $15,000 - $675 LMITO tax offset will be applied")]
        [Fact(DisplayName = "Given income of $37,000 - $675 LMITO tax offset will be applied")]
        [Fact(DisplayName = "Given income of $40,000 - $900 LMITO tax offset will be applied")]
        [Fact(DisplayName = "Given income of $45,000 - $1275 LMITO tax offset will be applied")]
        [Fact(DisplayName = "Given income of $55,000 - $1500 LMITO tax offset will be applied")]
        [Fact(DisplayName = "Given income of $70,000 - $1500 LMITO tax offset will be applied")]
        [Fact(DisplayName = "Given income of $92,000 - $1440 LMITO tax offset will be applied")]
        [Fact(DisplayName = "Given income of $120,000 - $600 LMITO tax offset will be applied")]
        [Fact(DisplayName = "Given income more than $126,000 - $0 LMITO tax offset will be applied")]
        */
    }
}
