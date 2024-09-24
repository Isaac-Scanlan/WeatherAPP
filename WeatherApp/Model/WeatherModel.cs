using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model.WeatherModelObjects;

namespace WeatherApp.Model;

/// <summary>
/// A model to represent the API response from the Weather website
/// </summary>
public record WeatherModel
{
    /// <summary>
    /// Name of the City that the weather is from.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// 'Main' attribute of API response
    /// </summary>
    public required Main Main {  get; set; }

    /// <summary>
    /// 'Weather' attribute of API response
    /// </summary>
    public required List<Weather> Weather { get; set; }
}
