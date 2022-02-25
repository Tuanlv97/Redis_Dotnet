using DemoRedis.Attributes;
using DemoRedis.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoRedis.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IResponseCacheService _responseCacheService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IResponseCacheService responseCacheService)
        {
            _logger = logger;
            _responseCacheService = responseCacheService;
        }


        [HttpGet("getall")]
        [Cache(1000)]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = new List<WeatherForecast>()
            {
                new WeatherForecast() { Id = 1 ,Name = "Lê Anh Tuấn 37", DateOfBirhtDay ="20/01/1997"},
                new WeatherForecast() { Id = 2, Name = "Lê Anh Tuấn 37", DateOfBirhtDay = "20/01/1996" },
                new WeatherForecast() { Id = 3 ,Name = "Lê Anh Tuấn 38", DateOfBirhtDay ="20/01/1995"},
                new WeatherForecast() { Id = 4 ,Name = "Lê Anh Tuấn 39", DateOfBirhtDay ="20/01/1991"},
            };
            return Ok(result);
        }

        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            await _responseCacheService.RemoveCacheResponseAsync("/weatherforecast/getall");
            return Ok();
        }

    }
}
