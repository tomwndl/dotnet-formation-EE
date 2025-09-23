using Microsoft.AspNetCore.Mvc;

namespace ExceptionMiddleware;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
  private static readonly string[] Summaries =
  [
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
  ];

  [HttpGet("GetWeather")]
  public string Get()
  {
    return Summaries[Random.Shared.Next(Summaries.Length)];
  }

  [HttpGet("GetBuggyWeather")]
  public string Boom()
  {
    throw new ApplicationException("BOOOM SENSITIVE INFO AN END USER SHOULD REALLY NOT SEE");
    return Summaries[Random.Shared.Next(Summaries.Length)];
  }
}
