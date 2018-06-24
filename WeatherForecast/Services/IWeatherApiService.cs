using WeatherForecast.Models;

namespace WeatherForecast.Services
{
    internal interface IWeatherApiService
    {
        CityWeather GetWeather(int id);

    }
}