using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using WeatherForecast.Models;
using WeatherForecast.Services;

namespace WeatherForecast.ViewModels
{
    public class MainWindowViewModel : PropertyChangedBase
    {
        private CityWeather _cityWeather;
        private BindableCollection<CityWeather> _cityWeathers;
        private String _cityName;
        private IWeatherApiService _service;
        private const String URL = "http://api.openweathermap.org/data/2.5/";
        private int JG = 7530796;



        public MainWindowViewModel()
        {
            _cityWeather = new CityWeather();
            _cityWeathers = new BindableCollection<CityWeather>();
            _service = new WeatherApiService(URL);
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
            get { return _cityName; }
         
            set
            {
                _cityName = value;
                NotifyOfPropertyChange("CityName");
                NotifyOfPropertyChange(() => CanAdd);
            }
        }


        public void Add()
        {
            if (!CityExists(CityName))
            {
                MessageBox.Show(string.Format("Added {0}!", _cityName));

                CityWeather cityWeather = _service.GetWeather(JG);
                _cityWeathers.Add(cityWeather);
               
            }
            else
                MessageBox.Show(string.Format("Hey {0} , it exists!", _cityName));
        }

        public bool CanAdd
        {
            get { return !CityExists(CityName); }
        }

        private bool CityExists(String _cityName)
        {
            if (_cityWeathers.Any(w => w.CityName == _cityName)) return true;

            return false;
        }

    }
}
