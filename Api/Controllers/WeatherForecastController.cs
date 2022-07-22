using Domain;
using Domain.Handlers;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Cities = new[]
    {
        "Vienna", "Copenhagen", "Zurich", "Geneva", "Frankfurt"
    };
    
    private readonly IMediator _mediator;

    public WeatherForecastController(IMediator mediator) => _mediator = mediator;

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> Get([FromQuery]GetWeatherForecast.Query request)
    {
        if (request.Days > 14 || request.Days < 1)
        {
            return BadRequest("Weather forecast only available for the next 14 days");
        }

        if(!Cities.Contains(request.City))
        {
            return BadRequest("This city is not in our list of cities");
        }
        
        var result = await _mediator.Send(request);
        
        return Ok(result);
    }
}