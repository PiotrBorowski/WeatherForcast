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
        private String _cityName;

     
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
                MessageBox.Show(string.Format("Hi {0}!", _cityName));
                _cityWeather = new CityWeather()
                {
                    CityName = _cityName
                };
                _cityWeathers.Add(_cityWeather);
            }
            else
                MessageBox.Show(string.Format("Hey {0} , you exists!", _cityName));
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
