using Fra.AspNetCore.Tests.Autowried.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fra.AspNetCore.Tests.Autowried.Services
{
    public interface IWeatherForecastServices
    {
        //IWeatherForecastRepository Repository { get; set; }

        //ILogger Logger { get; set; }

        IEnumerable<WeatherForecast> Generate();

    }
}
