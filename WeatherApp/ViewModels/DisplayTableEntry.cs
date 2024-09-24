using WeatherApp.Model;
using WeatherApp.Model.WeatherModelObjects;

namespace WeatherApp.ViewModels;

/// <summary>
/// The data structure beinf displayed in the display table
/// </summary>
public class DisplayTableEntry
{
    /// <summary>
    /// ID of weather data
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Air humodity of the air at the city
    /// </summary>
    public int Humidity { get; set; }

    /// <summary>
    /// Air pressure at the city
    /// </summary>
    public int Pressure { get; set; }

    /// <summary>
    /// Air temperature of city
    /// </summary>
    public double Temp { get; set; }

    /// <summary>
    /// City that the weather data is from
    /// </summary>
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// More detailed description of weather
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Type of weather present in the locatioon
    /// </summary>
    public string WeatherDescription { get; set; } = string.Empty;

    /// <summary>
    /// Code for Icon associated with weather type
    /// </summary>
    public string Icon { get; set; } = string.Empty;

    /// <summary>
    /// A static method used to map a WeatherModel object to a
    /// DisplayTableEntry object
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public static DisplayTableEntry ToDisplayTableEntry (WeatherModel model)
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
