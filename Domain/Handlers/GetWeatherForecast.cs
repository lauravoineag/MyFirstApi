using Domain.Contracts;
using Domain.Models;
using MediatR;

namespace Domain.Handlers;

public class GetWeatherForecast
{
    public record Query(string City, int Days = 5) : IRequest<CityForecast>;

    public class Handler : IRequestHandler<Query, CityForecast>
    {
        private readonly IForecaster _forecaster;

        public Handler(IForecaster forecaster) => _forecaster = forecaster;

        public Task<CityForecast> Handle(Query request, CancellationToken cancellationToken)
        {
            var (city, days) = request;//deconstruction
            
            var weatherForecasts = _forecaster.GetForecast(city, days);
            
            var forecast = new CityForecast()
            {
                City = city,
                WeatherForecasts = weatherForecasts
            };
           
            return Task.FromResult(forecast);
        }
    }
}