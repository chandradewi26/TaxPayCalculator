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
            try     //This doesnt work because, it seemed the swagger / api already had validation method
            {
                var resident = new Resident(income);
                var result = TaxPayCalculator.Calculate(resident);

                return Ok(result);
            }
            catch (Exception e)
            {
                throw new Exception("---");
            }
        }
    }
}