using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Tests.Services;

public class WeatherServicesTestData
{

    private static readonly List<object[]> _expectedJSON = new List<object[]>
    {
        new object[] {"Dublin", "300.59", "clear sky", "{\"coord\":{\"lon\":-121.9358,\"lat\":37.7021},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"base\":\"stations\",\"main\":{\"temp\":300.59,\"feels_like\":300.93,\"temp_min\":295.42,\"temp_max\":305.1,\"pressure\":1011,\"humidity\":49,\"sea_level\":1011,\"grnd_level\":987},\"visibility\":10000,\"wind\":{\"speed\":3.13,\"deg\":208,\"gust\":4.92},\"clouds\":{\"all\":0},\"dt\":1727043419,\"sys\":{\"type\":2,\"id\":2016191,\"country\":\"US\",\"sunrise\":1727013361,\"sunset\":1727057071},\"timezone\":-25200,\"id\":5344157,\"name\":\"Dublin\",\"cod\":200}"},
        new object[] {"London", "290.49", "broken clouds", "{\"coord\":{\"lon\":-0.1257,\"lat\":51.5085},\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"broken clouds\",\"icon\":\"04n\"}],\"base\":\"stations\",\"main\":{\"temp\":290.49,\"feels_like\":290.66,\"temp_min\":289.29,\"temp_max\":291.23,\"pressure\":1008,\"humidity\":91,\"sea_level\":1008,\"grnd_level\":1004},\"visibility\":10000,\"wind\":{\"speed\":2.57,\"deg\":70},\"clouds\":{\"all\":75},\"dt\":1727043990,\"sys\":{\"type\":2,\"id\":2075535,\"country\":\"GB\",\"sunrise\":1726984024,\"sunset\":1727027954},\"timezone\":3600,\"id\":2643743,\"name\":\"London\",\"cod\":200}"},
        new object[] {"Berlin", "288.38", "clear sky", "{\"coord\":{\"lon\":13.4105,\"lat\":52.5244},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01n\"}],\"base\":\"stations\",\"main\":{\"temp\":288.38,\"feels_like\":288.02,\"temp_min\":286.07,\"temp_max\":289.86,\"pressure\":1013,\"humidity\":79,\"sea_level\":1013,\"grnd_level\":1008},\"visibility\":10000,\"wind\":{\"speed\":1.03,\"deg\":90},\"clouds\":{\"all\":0},\"dt\":1727043907,\"sys\":{\"type\":2,\"id\":2011538,\"country\":\"DE\",\"sunrise\":1727067262,\"sunset\":1727110976},\"timezone\":7200,\"id\":2950159,\"name\":\"Berlin\",\"cod\":200}"},
        new object[] {"Paris", "288.8", "broken clouds", "{\"coord\":{\"lon\":2.3488,\"lat\":48.8534},\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"broken clouds\",\"icon\":\"04n\"}],\"base\":\"stations\",\"main\":{\"temp\":288.8,\"feels_like\":288.93,\"temp_min\":287.8,\"temp_max\":289.58,\"pressure\":1010,\"humidity\":96,\"sea_level\":1010,\"grnd_level\":1001},\"visibility\":10000,\"wind\":{\"speed\":3.09,\"deg\":200},\"clouds\":{\"all\":75},\"dt\":1727046320,\"sys\":{\"type\":2,\"id\":2012208,\"country\":\"FR\",\"sunrise\":1727069936,\"sunset\":1727113611},\"timezone\":7200,\"id\":2988507,\"name\":\"Paris\",\"cod\":200}"},
        new object[] {"Texas", "304.11", "overcast clouds", "{\"coord\":{\"lon\":-99.2506,\"lat\":31.2504},\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04d\"}],\"base\":\"stations\",\"main\":{\"temp\":304.11,\"feels_like\":304.79,\"temp_min\":304.07,\"temp_max\":304.12,\"pressure\":1008,\"humidity\":45,\"sea_level\":1008,\"grnd_level\":950},\"visibility\":10000,\"wind\":{\"speed\":4.12,\"deg\":150},\"clouds\":{\"all\":100},\"dt\":1727046336,\"sys\":{\"type\":1,\"id\":3395,\"country\":\"US\",\"sunrise\":1727007934,\"sunset\":1727051612},\"timezone\":-18000,\"id\":4736286,\"name\":\"Texas\",\"cod\":200}"},
        new object[] {"Athens", "293.22", "scattered clouds", "{\"coord\":{\"lon\":23.7162,\"lat\":37.9795},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"scattered clouds\",\"icon\":\"03n\"}],\"base\":\"stations\",\"main\":{\"temp\":293.22,\"feels_like\":292.59,\"temp_min\":290.98,\"temp_max\":294.44,\"pressure\":1017,\"humidity\":50,\"sea_level\":1017,\"grnd_level\":993},\"visibility\":10000,\"wind\":{\"speed\":2.57,\"deg\":330},\"clouds\":{\"all\":27},\"dt\":1727045690,\"sys\":{\"type\":2,\"id\":2005332,\"country\":\"GR\",\"sunrise\":1727064834,\"sunset\":1727108459},\"timezone\":10800,\"id\":264371,\"name\":\"Athens\",\"cod\":200}"}

    };

    private static readonly List<object[]> _expectedURLs = new List<object[]>
    {
        new object[] {"London", "https://api.openweathermap.org/data/2.5/weather?q=London&appid=fake-api-key", "{\"coord\":{\"lon\":-0.1257,\"lat\":51.5085},\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"broken clouds\",\"icon\":\"04n\"}],\"base\":\"stations\",\"main\":{\"temp\":290.49,\"feels_like\":290.66,\"temp_min\":289.29,\"temp_max\":291.23,\"pressure\":1008,\"humidity\":91,\"sea_level\":1008,\"grnd_level\":1004},\"visibility\":10000,\"wind\":{\"speed\":2.57,\"deg\":70},\"clouds\":{\"all\":75},\"dt\":1727043990,\"sys\":{\"type\":2,\"id\":2075535,\"country\":\"GB\",\"sunrise\":1726984024,\"sunset\":1727027954},\"timezone\":3600,\"id\":2643743,\"name\":\"London\",\"cod\":200}"},
        new object[] {"Dublin", "https://api.openweathermap.org/data/2.5/weather?q=Dublin&appid=fake-api-key", "{\"coord\":{\"lon\":-121.9358,\"lat\":37.7021},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"base\":\"stations\",\"main\":{\"temp\":300.59,\"feels_like\":300.93,\"temp_min\":295.42,\"temp_max\":305.1,\"pressure\":1011,\"humidity\":49,\"sea_level\":1011,\"grnd_level\":987},\"visibility\":10000,\"wind\":{\"speed\":3.13,\"deg\":208,\"gust\":4.92},\"clouds\":{\"all\":0},\"dt\":1727043419,\"sys\":{\"type\":2,\"id\":2016191,\"country\":\"US\",\"sunrise\":1727013361,\"sunset\":1727057071},\"timezone\":-25200,\"id\":5344157,\"name\":\"Dublin\",\"cod\":200}"},
        new object[] {"Berlin", "https://api.openweathermap.org/data/2.5/weather?q=Berlin&appid=fake-api-key", "{\"coord\":{\"lon\":13.4105,\"lat\":52.5244},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01n\"}],\"base\":\"stations\",\"main\":{\"temp\":288.38,\"feels_like\":288.02,\"temp_min\":286.07,\"temp_max\":289.86,\"pressure\":1013,\"humidity\":79,\"sea_level\":1013,\"grnd_level\":1008},\"visibility\":10000,\"wind\":{\"speed\":1.03,\"deg\":90},\"clouds\":{\"all\":0},\"dt\":1727043907,\"sys\":{\"type\":2,\"id\":2011538,\"country\":\"DE\",\"sunrise\":1727067262,\"sunset\":1727110976},\"timezone\":7200,\"id\":2950159,\"name\":\"Berlin\",\"cod\":200}"},
        new object[] {"Paris", "https://api.openweathermap.org/data/2.5/weather?q=Paris&appid=fake-api-key", "{\"coord\":{\"lon\":2.3488,\"lat\":48.8534},\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"broken clouds\",\"icon\":\"04n\"}],\"base\":\"stations\",\"main\":{\"temp\":288.8,\"feels_like\":288.93,\"temp_min\":287.8,\"temp_max\":289.58,\"pressure\":1010,\"humidity\":96,\"sea_level\":1010,\"grnd_level\":1001},\"visibility\":10000,\"wind\":{\"speed\":3.09,\"deg\":200},\"clouds\":{\"all\":75},\"dt\":1727046320,\"sys\":{\"type\":2,\"id\":2012208,\"country\":\"FR\",\"sunrise\":1727069936,\"sunset\":1727113611},\"timezone\":7200,\"id\":2988507,\"name\":\"Paris\",\"cod\":200}"},
        new object[] {"Texas", "https://api.openweathermap.org/data/2.5/weather?q=Texas&appid=fake-api-key", "{\"coord\":{\"lon\":-99.2506,\"lat\":31.2504},\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04d\"}],\"base\":\"stations\",\"main\":{\"temp\":304.11,\"feels_like\":304.79,\"temp_min\":304.07,\"temp_max\":304.12,\"pressure\":1008,\"humidity\":45,\"sea_level\":1008,\"grnd_level\":950},\"visibility\":10000,\"wind\":{\"speed\":4.12,\"deg\":150},\"clouds\":{\"all\":100},\"dt\":1727046336,\"sys\":{\"type\":1,\"id\":3395,\"country\":\"US\",\"sunrise\":1727007934,\"sunset\":1727051612},\"timezone\":-18000,\"id\":4736286,\"name\":\"Texas\",\"cod\":200}"},
        new object[] {"Athens", "https://api.openweathermap.org/data/2.5/weather?q=Athens&appid=fake-api-key", "{\"coord\":{\"lon\":23.7162,\"lat\":37.9795},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"scattered clouds\",\"icon\":\"03n\"}],\"base\":\"stations\",\"main\":{\"temp\":293.22,\"feels_like\":292.59,\"temp_min\":290.98,\"temp_max\":294.44,\"pressure\":1017,\"humidity\":50,\"sea_level\":1017,\"grnd_level\":993},\"visibility\":10000,\"wind\":{\"speed\":2.57,\"deg\":330},\"clouds\":{\"all\":27},\"dt\":1727045690,\"sys\":{\"type\":2,\"id\":2005332,\"country\":\"GR\",\"sunrise\":1727064834,\"sunset\":1727108459},\"timezone\":10800,\"id\":264371,\"name\":\"Athens\",\"cod\":200}"}
    };

    public static IEnumerable<object[]> GetData(WeatherServicesTestDataSet dataset)
    {
        var data = dataset switch
        {
            WeatherServicesTestDataSet.ApiResponseJSON => _expectedJSON,
            WeatherServicesTestDataSet.ApiDomain => _expectedURLs,
            _ => new List<object[]>()
        };

        return data;
    }
}
