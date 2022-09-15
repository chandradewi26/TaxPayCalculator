using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;

namespace TaxPayCalculator.API.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class RegionsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllRegions()
        {
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Wellington",
                    Code = "WLG",
                    Area = 222222,
                    Lat = -1.22222,
                    Long = 299.99,
                    Population = 500000,
                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Auckland",
                    Code = "AUCK",
                    Area = 33333,
                    Lat = -1.33333,
                    Long = 333.333,
                    Population = 400000,
                },
            };
            return Ok(regions);
        }
    }
}
