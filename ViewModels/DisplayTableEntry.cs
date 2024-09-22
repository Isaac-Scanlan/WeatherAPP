using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WeatherApp.ViewModels;

public class DisplayTableEntry
{
    public int Id { get; set; }
    public int Humidity { get; set; }
    public int Pressure { get; set; }
    public double Temp { get; set; }
    public string City { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Main { get; set; } = string.Empty;
    public string Icon;
}
