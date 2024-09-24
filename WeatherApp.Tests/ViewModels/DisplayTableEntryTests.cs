using AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model.WeatherModelObjects;
using WeatherApp.Model;
using WeatherApp.ViewModels;

namespace WeatherApp.Tests.ViewModels;

public class DisplayTableEntryTests
{
    private readonly Fixture _fixture;

    public DisplayTableEntryTests()
    {
        _fixture = new Fixture();
    }

    // Helper method to generate a WeatherModel with customizable weather entry
    private static WeatherModel CreateWeatherModel(string? description = "" , string? weatherDescription = "", 
        string? icon = "")
    {
        var fixture = new Fixture();
        return fixture.Build<WeatherModel>()
            .With(m => m.Weather,
            [
                new Weather
                {
                    Id = fixture.Create<int>(),
                    Description = description == "" ? fixture.Create<string>() : description,
                    WeatherDescription = weatherDescription == "" ? fixture.Create<string>() : weatherDescription,
                    Icon = icon == "" ? fixture.Create<string>() : icon
                }
            ])
            .Create();
    }

    [Fact]
    public void ToDisplayTableEntry_WhenModelIsValid_ShouldReturnValidDisplayTableEntry()
    {
        // Arrange
        var mockWeatherModel = CreateWeatherModel();

        // Act
        var entry = DisplayTableEntry.ToDisplayTableEntry(mockWeatherModel);

        // Assert
        Assert.Equal(mockWeatherModel.Weather[0].Id, entry.Id);
        Assert.Equal(mockWeatherModel.Main.Humidity, entry.Humidity);
        Assert.Equal(mockWeatherModel.Main.Pressure, entry.Pressure);
        Assert.Equal(mockWeatherModel.Main.Temp, entry.Temp);
        Assert.Equal(mockWeatherModel.Name, entry.City);  // Note this was corrected earlier
        Assert.Equal(mockWeatherModel.Weather[0].Description, entry.Description);
        Assert.Equal(mockWeatherModel.Weather[0].WeatherDescription, entry.WeatherDescription);
        Assert.Equal(mockWeatherModel.Weather[0].Icon, entry.Icon);
    }

    [Theory]
    [InlineData("Clear", "Clear Sky", null)]
    [InlineData("Clear", null, "Id0")]
    [InlineData(null, "Clear Sky", "Id0")]
    [InlineData(null, null, null)]
    public void ToDisplayTableEntry_WhenWeatherEntryFieldsAreNull_ShouldReturnDefaultStrings(string description, string weatherDescription, string icon)
    {
        // Arrange
        var mockWeatherModel = CreateWeatherModel(description, weatherDescription, icon);

        string expectedDescription = description ?? string.Empty;
        string expectedWeatherDescription = weatherDescription ?? string.Empty;
        string expectedIcon = icon ?? string.Empty;

        // Act
        var entry = DisplayTableEntry.ToDisplayTableEntry(mockWeatherModel);

        // Assert
        Assert.Equal(expectedDescription, entry.Description);
        Assert.Equal(expectedWeatherDescription, entry.WeatherDescription);
        Assert.Equal(expectedIcon, entry.Icon);
    }

}
