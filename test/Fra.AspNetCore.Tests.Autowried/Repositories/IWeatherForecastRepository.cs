using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fra.AspNetCore.Tests.Autowried.Repositories
{
    public interface IWeatherForecastRepository
    {
        IEnumerable<WeatherForecast> GetWeatherForecasts();
    }
}
