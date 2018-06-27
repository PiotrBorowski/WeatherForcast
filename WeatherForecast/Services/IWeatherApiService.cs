using System.Threading.Tasks;
using WeatherForecast.Models;

namespace WeatherForecast.Services
{
    internal interface IWeatherApiService
    {
        Task<CityWeather> GetWeather(int id);

    }
}