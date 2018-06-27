using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Caliburn.Micro;
using Newtonsoft.Json.Linq;
using WeatherForecast.Models;

namespace WeatherForecast.Services
{
    class WeatherApiService : IWeatherApiService
    {
        private String _url;

        public WeatherApiService(String url)
        {
            _url = url;
        }

        public async Task<CityWeather> GetWeather(int id)
        {
            return await Task.Run(() =>
            {
                CityWeather cityWeather;
                
                using (WebClient wc = new WebClient())
                {
                    var jsonString =
                        wc.DownloadString(
                            new Uri(_url + "weather?id=" + id + "&APPID=9235fcdf67a79075c7147fd12efecdd9"));
                    //MessageBox.Show(jsonString);
                    var json = JObject.Parse(jsonString);
                    DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();

                    cityWeather = new CityWeather()
                    {
                        CityName = Encoding.UTF8.GetString(
                            Encoding.Default.GetBytes(json["name"].ToString())), //czyta kodowanie znakow polskich
                        CityID = Int32.Parse(json["id"].ToString()),
                        Cloudiness = Int32.Parse(json["clouds"]["all"].ToString()),
                        Temperature = float.Parse(json["main"]["temp"].ToString()) - (float) 273.16,
                        Humidity = Int32.Parse(json["main"]["humidity"].ToString()),
                        Pressure = float.Parse(json["main"]["pressure"].ToString()),
                        DateTime = epoch.AddSeconds(Int32.Parse(json["dt"].ToString())).ToString("G"),
                        WindSpeed = float.Parse(json["wind"]["speed"].ToString()),    
                        Icon = new BitmapImage(new Uri("http://openweathermap.org/img/w/" +
                                                       json["weather"][0]["icon"] + ".png"))

                    };

                    try
                    {
                        cityWeather.RainVolume = float.Parse(json["rain"]["3h"].ToString());
                        cityWeather.SnowVolume =
                            float.Parse(json["snow"]["3h"].ToString()); //rzuca nulla bo nie ma snow w lato XD
                    }
                    catch (NullReferenceException)
                    {
                        cityWeather.RainVolume = 0;
                        cityWeather.SnowVolume = 0;
                    }

                    
                    return cityWeather;
                }
            });


        }
    }
}


