using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;
using System.Text.Json;
using System.IO;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace WeatherApp.Services;

public class WeatherService
{
    private static readonly HttpClient client = new();
    private readonly string apiKey;
    private readonly JsonSerializerOptions _options = new(){ PropertyNameCaseInsensitive = true };
    private readonly WeatherModel _weather = new WeatherModel()
    {
        Name = "",
        Main = new(),
        Weather = []
    };

    public WeatherService(IConfiguration configuration)
    {
        // Retrieve the API key from appsettings.Local.json
        apiKey = configuration["WeatherApi:ApiKey"] ?? throw new InvalidOperationException("API Key not found");
    }

    public async Task<WeatherModel> GetWeatherAsync(string city)
    {
        string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}";
        HttpResponseMessage? response = await client.GetAsync(url);

        if (response is not null && response.IsSuccessStatusCode)
        {
            string jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<WeatherModel>(jsonString, _options) ?? _weather;
        }

        return _weather;
    }
}
