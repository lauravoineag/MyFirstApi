namespace Domain.Models;

public class CityForecast
{
    public string City { get; set; }
    public IEnumerable<WeatherForecast> WeatherForecasts { get; set; }
}