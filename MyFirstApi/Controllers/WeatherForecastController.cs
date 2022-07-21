using Microsoft.AspNetCore.Mvc;

namespace MyFirstApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static readonly string[] Cities = new[]
    {
        "Vienna", "Copenhagen", "Zurich", "Geneva", "Frankfurt"
    };

    [HttpGet(Name = "GetWeatherForecast")]
    public IActionResult Get(string city,int days = 5)
    {
        if (days > 14 || days < 1)
        {
            return BadRequest("Weather forecast only available for the next 14 days");
        }

        if(!Cities.Contains(city))
        {
            return BadRequest("This city is not in our list of cities");
        }

        var weatherForecasts = Enumerable.Range(0, days).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index).ToString("D"),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
            })
            .ToArray();

        var result = new CityForecast()
        {
            City = city,
            WeatherForecasts = weatherForecasts
        };
        return Ok(result);
    }
}