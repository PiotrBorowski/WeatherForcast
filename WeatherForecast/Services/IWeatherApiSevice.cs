using WeatherForecast.Models;

namespace WeatherForecast.Services
{
    internal interface IWeatherApiSevice
    {
        CityWeather GetWeather(int ID);

    }
}