using AutoFixture;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.AutoMock;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;
using WeatherApp.Model.WeatherModelObjects;
using WeatherApp.Services;
using WeatherApp.ViewModels;

namespace WeatherApp.Tests.ViewModels;

public class MainViewModelTests
{
    private readonly AutoMocker _mocker;
    private readonly MainViewModel _viewModel;
    private readonly Fixture _fixture;
    private readonly WeatherModel _mockWeatherModel;

    public MainViewModelTests()
    {
        _mocker = new AutoMocker();
        _fixture = new Fixture();


        _mocker.GetMock<IConfiguration>()
            .Setup(c => c["WeatherApi:ApiKey"])
            .Returns("fake-api-key");

        _fixture.Customize<WeatherModel>(w => w
           .With(m => m.Weather, _fixture.CreateMany<Weather>(1).ToList()));


        _mockWeatherModel = _fixture.Create<WeatherModel>();

        _mocker.GetMock<WeatherService>()
               .Setup(service => service.GetWeatherAsync(It.IsAny<string>()))
               .ReturnsAsync(_mockWeatherModel);

        _viewModel = new MainViewModel(        
            _mocker.Get<WeatherService>());
    }

    [Fact]
    public async Task FetchWeatherCommand_ShouldPopulateDisplayTableCollection_OnSuccess()
    {
        // Arrange
        _viewModel.City = _mockWeatherModel.Name;
        _viewModel.DisplayTableCollection.Clear();

        // Act
        _viewModel.FetchWeatherCommand.Execute(null);

        await Task.Yield();

        // Assert
        
        Assert.Equal(_mockWeatherModel.Name, _viewModel.City);
        Assert.NotEmpty(_viewModel.DisplayTableCollection);
        Assert.Equal(_mockWeatherModel.Weather.First().Description, 
            _viewModel.DisplayTableCollection[0].Description);
    }


    [Fact]
    public async Task FetchWeatherCommand_WhenNoWeatherInfoAvailable_ShouldNotAddData()
    {
        // Arrange
        _viewModel.City = _mockWeatherModel.Name;
        _viewModel.DisplayTableCollection.Clear();

        WeatherModel emptyWeather = new ()
        {
            Name = "",
            Main = new(),
            Weather = []
        };

        _mocker.GetMock<WeatherService>()
               .Setup(service => service.GetWeatherAsync(It.IsAny<string>()))
               .ReturnsAsync(emptyWeather);

        // Act
        _viewModel.FetchWeatherCommand.Execute(null);

        await Task.Yield();

        // Assert
        Assert.Empty(_viewModel.DisplayTableCollection);

    }

    [Fact]
    public async Task FetchWeatherCommand_WhenCityHasExistingEntry_ShouldUpdateData()
    {
        // Arrange
        Fixture fixture = new ();
        fixture.Customize<WeatherModel>(w => w.With(n => n.Name, _mockWeatherModel.Name));

        var mockPreviousModel = fixture.Create<WeatherModel>();
        mockPreviousModel.Weather[0].Description += "A";
        var previousTableEntry = ConvertToDisplayTableEntry(mockPreviousModel);

        _viewModel.City = _mockWeatherModel.Name;
        _viewModel.DisplayTableCollection.Clear();
        _viewModel.DisplayTableCollection.Add(previousTableEntry);

        // Act
        _viewModel.FetchWeatherCommand.Execute(null);

        await Task.Yield();

        // Assert
        Assert.Equal(_mockWeatherModel.Name, _viewModel.City);
        Assert.NotEmpty(_viewModel.DisplayTableCollection);
        Assert.Equal(_mockWeatherModel.Weather.First().Description,
            _viewModel.DisplayTableCollection[0].Description);
        Assert.NotEqual(previousTableEntry.Description,
            _viewModel.DisplayTableCollection[0].Description);

    }

    [Fact]
    public void ClearTableCommand_ShouldClearDataTable()
    {
        // Arrange
        var tableEntry = _fixture.Create<DisplayTableEntry>();
        _viewModel.DisplayTableCollection.Add(tableEntry);

        // Act
        _viewModel.ClearTableCommand.Execute(null);

        // Assert
        Assert.Empty(_viewModel.DisplayTableCollection);
    }

    [Fact]
    public void PropertyChanged_WhenCityChanges_ShouldRaiseEvent()
    {
        // Arrange
        bool eventRaised = false;

        _viewModel.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == nameof(MainViewModel.City))
            {
                eventRaised = true;
            }
        };

        // Act
        _viewModel.City = "New York";

        // Assert
        Assert.True(eventRaised);
    }

    private static DisplayTableEntry ConvertToDisplayTableEntry(WeatherModel model)
    {
        Weather weatherEntry = model.Weather.First();
        return new DisplayTableEntry
        {
            Id = weatherEntry.Id,
            Humidity = model.Main.Humidity,
            Pressure = model.Main.Pressure,
            Temp = model.Main.Temp,
            City = model.Name,
            Description = weatherEntry.Description ?? string.Empty,
            WeatherDescription = weatherEntry.WeatherDescription ?? string.Empty,
            Icon = weatherEntry.Icon ?? string.Empty
        };
    }



}
