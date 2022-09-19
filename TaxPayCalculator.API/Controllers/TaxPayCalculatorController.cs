using Microsoft.AspNetCore.Mvc;

namespace TaxPayCalculator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxPayCalculatorController : Controller
    {
        public TaxPayCalculatorController(){ }

        [HttpGet]
        public IActionResult GetTaxResult(decimal income)
        {
            var calculator = new TaxPayCalculator();
            var resident = new Resident(income);
            var result = calculator.Calculate(resident);

            return Ok(result);
        }
    }
}
