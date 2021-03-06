﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace WeatherForecast.Models
{
    public class CityWeather 
    {
        public CityWeather()
        {
        }

        public int CityID { get; set; }
        public String CityName { get; set; }
        public float Temperature { get; set; }
        public float Pressure { get; set; }
        public int Humidity { get; set; }
        public float Cloudiness { get; set; } 
        public float WindSpeed { get; set; }
        public float RainVolume { get; set; }
        public float SnowVolume { get; set; }
        public String DateTime { get; set; }
        public ImageSource Icon { get; set; }
    }
}
