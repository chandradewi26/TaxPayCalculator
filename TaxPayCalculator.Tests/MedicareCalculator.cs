using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /*
        [Fact(DisplayName = "Given income of $15,000 - $0 medicare tax will be applied")]
        [Fact(DisplayName = "Given income of $37,000 - $740 medicare tax will be applied")]
        [Fact(DisplayName = "Given income of $40,000 - $800 medicare tax will be applied")]
        [Fact(DisplayName = "Given income of $45,000 - $900 medicare tax will be applied")]
        [Fact(DisplayName = "Given income of $55,000 - $1,100 medicare tax will be applied")]
        [Fact(DisplayName = "Given income of $70,000 - $1,400 medicare tax will be applied")]
        [Fact(DisplayName = "Given income of $92,000 - $1,840 medicare tax will be applied")]
        [Fact(DisplayName = "Given income of $120,000 - $2,400 medicare tax will be applied")]
        [Fact(DisplayName = "Given income of $150,000 - $3,000 medicare tax will be applied")]
        [Fact(DisplayName = "Given income of $180,000 - $3,600 medicare tax will be applied")]
        [Fact(DisplayName = "Given income of $200,000 - $4,000 medicare tax will be applied")]
        */
    }
}
