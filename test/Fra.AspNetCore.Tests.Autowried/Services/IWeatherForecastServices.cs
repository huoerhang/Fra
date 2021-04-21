using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fra.AspNetCore.Tests.Autowried.Services
{
    public interface IWeatherForecastServices
    {
        IEnumerable<WeatherForecast> Generate();
    }
}
