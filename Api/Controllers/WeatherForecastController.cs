using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IMediator _mediator;
    
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static readonly string[] Cities = new[]
    {
        "Vienna", "Copenhagen", "Zurich", "Geneva", "Frankfurt"
    };

    public WeatherForecastController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> Get([FromQuery]GetWeatherForecast.Command request)
    {
        var outcome = await _mediator.Send(request);
        if (request.Days > 14 || request.Days < 1)
        {
            return BadRequest("Weather forecast only available for the next 14 days");
        }

        if(!Cities.Contains(request.City))
        {
            return BadRequest("This city is not in our list of cities");
        }

        var weatherForecasts = Enumerable.Range(0, request.Days).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index).ToString("D"),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
            })
            .ToArray();

        var result = new CityForecast()
        {
            City = request.City,
            WeatherForecasts = weatherForecasts
        };
        return Ok(result);
    }
}