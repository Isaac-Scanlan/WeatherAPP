using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherApp.Model;

public class Weather
{
    /// <summary>
    /// 
    /// </summary>
    public int Id { get; set; }

    [JsonPropertyName("main")]
    public string WeatherDescription { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
}
