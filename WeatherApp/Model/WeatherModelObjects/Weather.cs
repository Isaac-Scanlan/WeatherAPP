using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherApp.Model.WeatherModelObjects;

/// <summary>
/// The Weather object of the WeatherModel API response
/// </summary>
public record Weather
{
    /// <summary>
    /// ID of Weather data retrieved
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the description of the weather.
    /// This property is serialized to JSON using the name "main".
    /// </summary>
    [JsonPropertyName("main")]
    public string? WeatherDescription { get; set; }

    /// <summary>
    /// More detailed weather description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// The Icon code for the weather
    /// </summary>
    public string? Icon { get; set; }
}
