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

/// <summary>
/// Service used to connect to openweathermap.org and retrieve weather data 
/// on a specific city
/// </summary>
public class WeatherService
{
    private static readonly HttpClient _client = new();
    private readonly string apiKey;
    private readonly JsonSerializerOptions _options;
    private readonly WeatherModel _weather;

    /// <summary>
    /// Constuctor retrieves API key, and initialises necessary objects
    /// </summary>
    /// <param name="configuration"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public WeatherService(IConfiguration configuration)
    {
        apiKey = configuration["WeatherApi:ApiKey"] ?? throw new InvalidOperationException("API Key not found");

        _weather = new WeatherModel()
        {
            Name = "",
            Main = new(),
            Weather = []
        };

        _options = new() { PropertyNameCaseInsensitive = true };
    }

    /// <summary>
    /// Makes an API request to openweathermap.org to get the weather for a specific city
    /// </summary>
    /// <param name="city"></param>
    /// <returns></returns>
    public async Task<WeatherModel> GetWeatherAsync(string city)
    {
        string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}";

        HttpResponseMessage? response = await _client.GetAsync(url);

        if (response is not null && response.IsSuccessStatusCode)
        {
            string jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<WeatherModel>(jsonString, _options) ?? _weather;
        }

        return _weather;
    }
}
