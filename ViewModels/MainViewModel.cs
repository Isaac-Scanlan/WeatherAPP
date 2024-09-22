using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WeatherApp.Helpers;
using WeatherApp.Model;
using WeatherApp.Services;

namespace WeatherApp.ViewModels;

internal class MainViewModel : INotifyPropertyChanged
{
    private ObservableCollection<DisplayTableEntry> _dataTableCollection { get; set; }
    private readonly WeatherService _weatherService;
    private WeatherModel _weather;
    private string _city;

    public WeatherModel Weather
    {
        get => _weather;
        set
        {
            _weather = value;
            OnPropertyChanged(nameof(Weather));
        }
    }
    public string City
    {
        get => _city;
        set
        {
            _city = value;
            OnPropertyChanged(nameof(City));
        }
    }
    public ObservableCollection<DisplayTableEntry> DisplayTableCollection
    {
        get { return _dataTableCollection; }
        set
        {
            _dataTableCollection = value;
            OnPropertyChanged(nameof(DisplayTableCollection));
        }
    }

    public RelayCommand FetchWeatherCommand { get; }
    public ICommand ClearTableCommand { get; }

    public MainViewModel(IConfiguration configuration)
    {
        _weatherService = new(configuration);
        _weather = new()
        {
            Name = "",
            Main = new(),
            Weather = new()
        };
        _city = "";
        _dataTableCollection = [];

        FetchWeatherCommand = new RelayCommand(async () => await GetWeatherAsync());
        ClearTableCommand = new WeatherApp.View.Controls.RelayCommand(ClearTable);
    }

    private async Task GetWeatherAsync()
    {
        Weather = await _weatherService.GetWeatherAsync(City);
        if(Weather.Weather.Count is 0)
        {
            return;
        }
        _dataTableCollection.Add(new()
        {
            Id = Weather.Weather[0].Id,
            Humidity = Weather.Main.Humidity,
            Pressure = Weather.Main.Pressure,
            Temp = Weather.Main.Temp,
            City = _city,
            Description = Weather.Weather[0].Description,
            Main = Weather.Weather[0].WeatherDescription,
            Icon = Weather.Weather[0].Icon
        });
    }

    private void ClearTable()
    {
        _dataTableCollection.Clear();
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


}
