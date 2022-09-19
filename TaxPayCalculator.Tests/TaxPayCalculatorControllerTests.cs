using Microsoft.AspNetCore.Mvc;
using TaxPayCalculator.API.Controllers;

namespace TaxPayCalculator.Tests
{
    public class TaxPayCalculatorControllerTests
    {
        [Fact(DisplayName = "Given income of $15,000 - $0 tax will be applied")]
        public void TestTaxPayCalculatorController_GivenIncome15000_Return0AmountOfTax()
        {
            var controller = new TaxPayCalculatorController();
            //Act
            IActionResult result = controller.GetTaxResult(15000);

            //Need to convert to actual action result Type
            OkObjectResult? okResult = result as OkObjectResult;

            //Assert
            Assert.NotNull(okResult);
            decimal actualResult = (decimal)okResult.Value;
            Assert.Equal(0, actualResult);
        }

        [Theory(DisplayName = "Given income, The Web Api should return the correct tax amount")]
        [InlineData(15000, 0)]
        [InlineData(37000, 2937)]
        [InlineData(40000, 3467)]
        [InlineData(45000, 4392)]
        [InlineData(55000, 7767)]
        [InlineData(70000, 13117)]
        [InlineData(92000, 20767)]
        [InlineData(120000, 31267)]
        [InlineData(150000, 43567)]
        [InlineData(180000, 55267)]
        [InlineData(200000, 64667)]
        public void TestTaxPayCalculatorController_GivenIncome_ReturnCorrectAmountOfTax(decimal inputValue, decimal expectedOutput)
        {
            var controller = new TaxPayCalculatorController();
            //Act
            IActionResult result = controller.GetTaxResult(inputValue);

            //Need to convert to actual action result Type
            OkObjectResult? okResult = result as OkObjectResult;

            //Assert
            Assert.NotNull(okResult);
            decimal actualResult = (decimal)okResult.Value;
            Assert.Equal(expectedOutput, actualResult);
        }
    }
}

//Following : 
//https://stackoverflow.com/questions/69803242/how-to-create-a-unit-test-for-an-iactionresult-controller-action-which-returns-d