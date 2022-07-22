using Domain.Models;

namespace Domain.Contracts;

public interface IForecaster
{
  IEnumerable<WeatherForecast> GetForecast(string city, int days);
}

public class Forecaster : IForecaster
{
  public IEnumerable<WeatherForecast> GetForecast(string city, int days)
  {
      var summaries = new[]
      {
          "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
      };
      var weatherForecasts = Enumerable.Range(0, days).Select(index => new WeatherForecast
      {
          Date = DateTime.Now.AddDays(index).ToString("D"),
          TemperatureC = Random.Shared.Next(-20, 55),
          Summary = summaries[Random.Shared.Next(summaries.Length)],
      });

      return weatherForecasts;
  }
}