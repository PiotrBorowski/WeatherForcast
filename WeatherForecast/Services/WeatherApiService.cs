using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        public CityWeather GetWeather(int id)
        {
            CityWeather cityWeather;

            using (WebClient wc = new WebClient())
            {
                var jsonString = wc.DownloadString(_url + "weather?id=" + id + "&APPID=9235fcdf67a79075c7147fd12efecdd9");
                //MessageBox.Show(jsonString);
                var json = JObject.Parse(jsonString);
                DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
               
                cityWeather = new CityWeather()
               {
                   CityName = Encoding.UTF8.GetString(Encoding.Default.GetBytes(json["name"].ToString())), //czyta kodowanie znakow polskich
                   CityID = Int32.Parse(json["id"].ToString()),
                   Cloudiness = Int32.Parse(json["clouds"]["all"].ToString()),
                   Temperature = float.Parse(json["main"]["temp"].ToString()) - (float)273.16,
                   Humidity = Int32.Parse(json["main"]["humidity"].ToString()),
                   Pressure = float.Parse(json["main"]["pressure"].ToString()),
                   DateTime = epoch.AddSeconds(Int32.Parse(json["dt"].ToString())).ToString("G"),


            };
                
            }

            return cityWeather;
            
        }
    }
}
