using MediatR;

namespace Domain;

public class GetWeatherForecast
{
    public record Command(string City, int Days = 5) : IRequest<CityForecast>;

    public class Handler : IRequestHandler<Command, CityForecast>
    {
        public async Task<CityForecast> Handle(Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("Boooo!");
        }
    }
}


