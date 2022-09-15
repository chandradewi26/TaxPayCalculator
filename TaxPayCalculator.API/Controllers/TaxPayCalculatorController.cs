using Microsoft.AspNetCore.Mvc;

namespace TaxPayCalculator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxPayCalculatorController : Controller
    {
            [HttpGet]
            public IActionResult GetTaxResult(decimal income)
            {
                var _calculator = new TaxPayCalculator();

                var _resident = new Resident(income);
                var result = _calculator.Calculate(_resident);
                return Ok(result);
            }
        }
    }
