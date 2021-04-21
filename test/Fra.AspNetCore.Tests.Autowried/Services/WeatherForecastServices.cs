using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspectCore.DependencyInjection;
using Fra.AspNetCore.Tests.Autowried.Repositories;
using Fra.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Fra.AspNetCore.Tests.Autowried.Services
{
    [Dependency]
    public class WeatherForecastServices : IWeatherForecastServices
    {
        [AutowiredAttribute]
        public IWeatherForecastRepository Repository { get; set; }

        [AutowiredAttribute]
        public ILogger<WeatherForecastServices> Logger { get; set; }



        //public WeatherForecastServices(IWeatherForecastRepository repository)
        //{
        //    _repository = repository;
        //}
        [CustomInterceptorAttribute]
        public IEnumerable<WeatherForecast> Generate()
        {
            Logger.LogInformation(nameof(WeatherForecastServices.Generate));
            return Repository.GetWeatherForecasts();
        }

    }
}
