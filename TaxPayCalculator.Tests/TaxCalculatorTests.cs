using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Calculate raw tax without offset and medicare
 Both year 2021-22 & 2022-23*/
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

        /*
        [Fact(DisplayName = "Given income of $15,000 - $0 tax will be applied")]
        [Fact(DisplayName = "Given income of $37,000 - $3,572 tax will be applied")]
        [Fact(DisplayName = "Given income of $40,000 - $4,142 tax will be applied")]
        [Fact(DisplayName = "Given income of $45,000 - $5,092 tax will be applied")]
        [Fact(DisplayName = "Given income of $55,000 - $8,342 tax will be applied")]
        [Fact(DisplayName = "Given income of $70,000 - $13,217 tax will be applied")]
        [Fact(DisplayName = "Given income of $92,000 - $20,367 tax will be applied")]
        [Fact(DisplayName = "Given income of $120,000 - $29,467 tax will be applied")]
        [Fact(DisplayName = "Given income of $150,000 - $40,567 tax will be applied")]
        [Fact(DisplayName = "Given income of $180,000 - $51,667 tax will be applied")]
        [Fact(DisplayName = "Given income of $200,000 - $60,667 tax will be applied")]
        */
    }
}
