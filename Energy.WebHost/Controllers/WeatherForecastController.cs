using Energy.DAL.Context;
using Energy.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Energy.WebHost.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        private readonly ILogger<WeatherForecastController> _logger;
        private readonly EnergyContext _energyContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, EnergyContext energyContext)
        {
            _logger = logger;
            _energyContext = energyContext;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult AddNewMeasuringPoint()
        {
            //using (_energyContext) 
            //{
            //    Organization organization = new Organization("Тестовая организация", "Москва");
            //    _energyContext.Add<Organization>(organization);
            //}
            return Ok();
        }
    }
}