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

/// <summary>
/// The view model that manages weather data, city input, and commands for fetching weather and clearing data.
/// Implements <see cref="INotifyPropertyChanged"/> to notify the view of changes.
/// </summary>
internal class MainViewModel : INotifyPropertyChanged
{
    private readonly WeatherService _weatherService;
    private WeatherModel _weather;
    private string _city;
    private ObservableCollection<DisplayTableEntry> _dataTableCollection;

    /// <summary>
    /// Gets or sets the current weather model.
    /// Notifies the view when the property changes.
    /// </summary>
    public WeatherModel Weather
    {
        get => _weather;
        set
        {
            _weather = value;
            OnPropertyChanged(nameof(Weather));
        }
    }

    /// <summary>
    /// Gets or sets the name of the city for which the weather is being retrieved.
    /// Notifies the view when the property changes.
    /// </summary>
    public string City
    {
        get => _city;
        set
        {
            _city = value;
            OnPropertyChanged(nameof(City));
        }
    }

    /// <summary>
    /// Gets or sets the collection of weather data entries displayed in the table.
    /// Notifies the view when the property changes.
    /// </summary>
    public ObservableCollection<DisplayTableEntry> DisplayTableCollection
    {
        get => _dataTableCollection;
        set
        {
            _dataTableCollection = value;
            OnPropertyChanged(nameof(DisplayTableCollection));
        }
    }

    /// <summary>
    /// Command to fetch the weather data based on the entered city.
    /// </summary>
    public ICommand FetchWeatherCommand { get; }

    /// <summary>
    /// Command to clear the data table.
    /// </summary>
    public ICommand ClearTableCommand { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MainViewModel"/> class.
    /// Sets up the weather service, initializes the data collection and commands.
    /// </summary>
    /// <param name="configuration">The configuration object used to initialize the weather service.</param>
    public MainViewModel(IConfiguration configuration)
    {
        _weatherService = new WeatherService(configuration);
        _weather = new WeatherModel
        {
            Name = string.Empty,
            Main = new(),
            Weather = new()
        };
        _city = string.Empty;
        _dataTableCollection = new ObservableCollection<DisplayTableEntry>();

        FetchWeatherCommand = new RelayCommand(async () => await GetWeatherAsync());
        ClearTableCommand = new RelayCommand(ClearTable);
    }

    /// <summary>
    /// Fetches weather data asynchronously based on the <see cref="City"/> property.
    /// Populates the <see cref="DisplayTableCollection"/> with the retrieved data.
    /// </summary>
    private async Task GetWeatherAsync()
    {
        Weather = await _weatherService.GetWeatherAsync(City);
        if (Weather.Weather.Count == 0) return;

        var weatherEntry = Weather.Weather.FirstOrDefault();
        if (weatherEntry == null) return;

        _dataTableCollection.Add(new DisplayTableEntry
        {
            Id = weatherEntry.Id,
            Humidity = Weather.Main.Humidity,
            Pressure = Weather.Main.Pressure,
            Temp = Weather.Main.Temp,
            City = City,
            Description = weatherEntry.Description ?? string.Empty,
            WeatherDescription = weatherEntry.WeatherDescription ?? string.Empty,
            Icon = weatherEntry.Icon ?? string.Empty
        });
    }

    /// <summary>
    /// Clears the <see cref="DisplayTableCollection"/>.
    /// </summary>
    private void ClearTable() => _dataTableCollection.Clear();

    /// <summary>
    /// Event raised when a property value changes.
    /// Implements <see cref="INotifyPropertyChanged.PropertyChanged"/>.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Notifies listeners that a property value has changed.
    /// </summary>
    /// <param name="propertyName">The name of the property that changed.</param>
    protected void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}


