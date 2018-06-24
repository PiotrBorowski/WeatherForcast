using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using WeatherForecast.Models;

namespace WeatherForecast.ViewModels
{
    public class MainWindowViewModel : PropertyChangedBase
    {
        private readonly CityWeather _weather;

        public MainWindowViewModel()
        {
            _weather = new CityWeather();
        }

        public string CityName
        {
            get
            {
                return _weather.CityName;

            }
            set
            {
                _weather.CityName = value;
                NotifyOfPropertyChange("CityName");
                NotifyOfPropertyChange(() => CanAdd);
            }
        }

        public float Temperature
        {
            get
            {
                return _weather.Temperature;

            }
            set
            {
                _weather.Temperature = value;
                NotifyOfPropertyChange("Temperature");
            }
        }

        public float Pressure
        {
            get
            {
                return _weather.Pressure;

            }
            set
            {
                _weather.Pressure = value;
                NotifyOfPropertyChange("Pressure");
            }
        }
        public int Humidity
        {
            get
            {
                return _weather.Humidity;

            }
            set
            {
                _weather.Humidity = value;
                NotifyOfPropertyChange("Humidity");
            }
        }
        public float Cloudiness
        {
            get
            {
                return _weather.Cloudiness;

            }
            set
            {
                _weather.Cloudiness = value;
                NotifyOfPropertyChange("Cloudiness");
            }
        }
        public float WindSpeed
        {
            get
            {
                return _weather.WindSpeed;

            }
            set
            {
                _weather.WindSpeed = value;
                NotifyOfPropertyChange("WindSpeed");
            }
        }
        public float RainVolume
        {
            get
            {
                return _weather.RainVolume;

            }
            set
            {
                _weather.Pressure = value;
                NotifyOfPropertyChange("RainVolume");
            }
        }
        public float SnowVolume
        {
            get
            {
                return _weather.SnowVolume;

            }
            set
            {
                _weather.SnowVolume = value;
                NotifyOfPropertyChange("SnowVolume");
            }
        }
        public DateTime DateTime
        {
            get
            {
                return _weather.DateTime;

            }
            set
            {
                _weather.DateTime = value;
                NotifyOfPropertyChange("DateTime");
            }
        }

        public String Icon
        {
            get
            {
                return _weather.Icon;

            }
            set
            {
                _weather.Icon = value;
                NotifyOfPropertyChange("Icon");
            }
        }

        public void Add()
        {
            if (!CityExists(_weather))
            {
                MessageBox.Show(string.Format("Hi {0}!", _weather.CityName));
            }
            else
                MessageBox.Show(string.Format("Hey {0} , you exists!", _weather.CityName));
        }

        public bool CanAdd
        {
            get { return !CityExists(_weather); }
        }

        private bool CityExists(CityWeather _weather)
        {
            //Some logic
            return false;
        }

    }
}
