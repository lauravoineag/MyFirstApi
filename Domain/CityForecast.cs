namespace Domain;

//ViewModel

public class CityForecast
{
    public string City { get; set; }
    public IEnumerable<WeatherForecast> WeatherForecasts { get; set; }
}