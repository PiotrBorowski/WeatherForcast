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
        private CityWeather _cityWeather;
        private BindableCollection<CityWeather> _cityWeathers;

     
        public MainWindowViewModel()
        {
            _cityWeather = new CityWeather();
            _cityWeathers = new BindableCollection<CityWeather>();
        }

        public CityWeather SelectedCityWeather
        {
            get { return _cityWeather; }
            set
            {
                _cityWeather = value;
                NotifyOfPropertyChange("SelectedCityWeather");
            }
        }

        public BindableCollection<CityWeather> CityWeathers
        {
            get { return _cityWeathers; }
            set
            {
                _cityWeathers = value;
                NotifyOfPropertyChange("CityWeathers");
            }
        }

        public string CityName
        {
            get
            {
                return _cityWeather.CityName;

            }
            set
            {
                _cityWeather.CityName = value;
                NotifyOfPropertyChange("CityName");
                NotifyOfPropertyChange(() => CanAdd);
            }
        }

        public float Temperature
        {
            get
            {
                return _cityWeather.Temperature;

            }
            set
            {
                _cityWeather.Temperature = value;
                NotifyOfPropertyChange("Temperature");
            }
        }

        public float Pressure
        {
            get
            {
                return _cityWeather.Pressure;

            }
            set
            {
                _cityWeather.Pressure = value;
                NotifyOfPropertyChange("Pressure");
            }
        }
        public int Humidity
        {
            get
            {
                return _cityWeather.Humidity;

            }
            set
            {
                _cityWeather.Humidity = value;
                NotifyOfPropertyChange("Humidity");
            }
        }
        public float Cloudiness
        {
            get
            {
                return _cityWeather.Cloudiness;

            }
            set
            {
                _cityWeather.Cloudiness = value;
                NotifyOfPropertyChange("Cloudiness");
            }
        }
        public float WindSpeed
        {
            get
            {
                return _cityWeather.WindSpeed;

            }
            set
            {
                _cityWeather.WindSpeed = value;
                NotifyOfPropertyChange("WindSpeed");
            }
        }
        public float RainVolume
        {
            get
            {
                return _cityWeather.RainVolume;

            }
            set
            {
                _cityWeather.Pressure = value;
                NotifyOfPropertyChange("RainVolume");
            }
        }
        public float SnowVolume
        {
            get
            {
                return _cityWeather.SnowVolume;

            }
            set
            {
                _cityWeather.SnowVolume = value;
                NotifyOfPropertyChange("SnowVolume");
            }
        }
        public DateTime DateTime
        {
            get
            {
                return _cityWeather.DateTime;

            }
            set
            {
                _cityWeather.DateTime = value;
                NotifyOfPropertyChange("DateTime");
            }
        }

        public String Icon
        {
            get
            {
                return _cityWeather.Icon;

            }
            set
            {
                _cityWeather.Icon = value;
                NotifyOfPropertyChange("Icon");
            }
        }

        public void Add()
        {
            if (!CityExists(_cityWeather))
            {
                MessageBox.Show(string.Format("Hi {0}!", _cityWeather.CityName));
                _cityWeathers.Add(_cityWeather);
            }
            else
                MessageBox.Show(string.Format("Hey {0} , you exists!", _cityWeather.CityName));
        }

        public bool CanAdd
        {
            get { return !CityExists(_cityWeather); }
        }

        private bool CityExists(CityWeather _weather)
        {
            if (_cityWeathers.Contains(_weather)) return true;

            return false;
        }

    }
}
