using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model;

/// <summary>
/// "Main" attribute of API response from weather site
/// </summary>
public class Main
{
    /// <summary>
    /// Temperature of requested location
    /// </summary>
    public double Temp {  get; set; }

    /// <summary>
    /// Humidity of requested location
    /// </summary>
    public int Humidity { get; set; }

    /// <summary>
    /// Air pressure of requested location
    /// </summary>
    public int Pressure { get; set; }
}
