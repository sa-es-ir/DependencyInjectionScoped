using Microsoft.AspNetCore.Mvc;

namespace AspNetDependecyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly SingletonServices singletonServices;
        private readonly ScopedServices scopedServices;
        private readonly TransientServices transientServices;
        private readonly DataService dataService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            SingletonServices singletonServices,
            ScopedServices scopedServices,
            TransientServices transientServices,
            DataService dataService)
        {
            _logger = logger;
            this.singletonServices = singletonServices;
            this.scopedServices = scopedServices;
            this.transientServices = transientServices;
            this.dataService = dataService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            dataService.DoSomething();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}