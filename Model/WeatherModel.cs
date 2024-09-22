using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model;

public class WeatherModel
{
    public required string Name { get; set; }
    public required Main Main {  get; set; }
    public required List<Weather> Weather { get; set; }
}
