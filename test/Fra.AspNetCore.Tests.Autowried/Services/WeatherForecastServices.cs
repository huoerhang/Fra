using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fra.AspNetCore.Tests.Autowried.Repositories;
using Fra.DependencyInjection;

namespace Fra.AspNetCore.Tests.Autowried.Services
{
    [Dependency]
    public class WeatherForecastServices : IWeatherForecastServices
    {
        public IWeatherForecastRepository Repository { get; set; }

        //public WeatherForecastServices(IWeatherForecastRepository repository)
        //{
        //    _repository = repository;
        //}

        public IEnumerable<WeatherForecast> Generate()
        {
            return Repository.GetWeatherForecasts();
        }
    }
}
