using Microsoft.AspNetCore.Mvc;

namespace TaxPayCalculator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxPayCalculatorController : Controller
    {
        private readonly ICalculator TaxPayCalculator;
        public TaxPayCalculatorController(ICalculator taxPayCalculator)
        {
            TaxPayCalculator = taxPayCalculator;
        }

        [HttpGet]
        public IActionResult GetTaxResult(decimal income)
        {
            var resident = new Resident(income);
            var result = TaxPayCalculator.Calculate(resident);

            return Ok(result);
        }
    }
}

/*
namespace TaxPayCalculator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxPayCalculatorController : Controller
    {
        private readonly ICalculator TaxPayCalculator;

        public TaxPayCalculatorController()
        {
        }

        public TaxPayCalculatorController(ICalculator taxPayCalculator) 
        {
            TaxPayCalculator = taxPayCalculator;
        }

        [HttpGet]
        //public IActionResult GetTaxResult(string income)
        public IActionResult GetTaxResult(decimal income)
        {
            //If I didnt change the parameter to string, it looked like they already had auto input type check
            //Testing try catch manually
            try
            {
                //var dec_income = decimal.Parse(income);
                //var resident = new Resident(dec_income);

                var resident = new Resident(income); 
                var result = TaxPayCalculator.Calculate(resident);
                return Ok(result);
                
            }
            catch (Exception e)
            {
                throw new Exception("Input was not a valid numerical number");
            }
        }
    }
}
*/