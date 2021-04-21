using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fra.DependencyInjection;
using Fra.AspNetCore.Tests.Autowried.Services;

namespace Fra.AspNetCore.Tests.Autowried.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        //[Autowired]
        protected IWeatherForecastServices WeatherForecastServices { get; set; }

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastServices weatherForecastServices)
        {
            _logger = logger;
            WeatherForecastServices = weatherForecastServices;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return WeatherForecastServices.Generate();
        }
    }
}
