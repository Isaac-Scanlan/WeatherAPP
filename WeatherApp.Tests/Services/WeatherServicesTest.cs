using AutoFixture;
using AutoFixture.AutoMoq;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Services;
using System.Net;
using System.Net.Http;

namespace WeatherApp.Tests.Services;

public class WeatherServicesTest
{
    private readonly IFixture _fixture;

    public WeatherServicesTest()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());

        _fixture.Freeze<Mock<IConfiguration>>()
            .Setup(c => c["WeatherApi:ApiKey"])
            .Returns("fake-api-key");
    }

    [Theory]
    [MemberData(nameof(WeatherServicesTestData.GetData), parameters: WeatherServicesTestDataSet.ApiResponseJSON, MemberType = typeof(WeatherServicesTestData))]
    public async Task GetWeatherAsync_WhenApiCallIsSuccessful_ShouldReturnWeatherModel(
        string city, double temp, string weather, string expectedJson)
    {
        // Act
        var mockHttpMessageHandler = _fixture.Freeze<Mock<HttpMessageHandler>>();

        mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get
                ),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(expectedJson)
            });

        var httpClient = new HttpClient(mockHttpMessageHandler.Object);

        // Act
        var weatherService = new WeatherService(httpClient, _fixture.Create<IConfiguration>());
        var result = await weatherService.GetWeatherAsync(city);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(city, result.Name); 
        Assert.Equal(temp, result.Main.Temp); 
        Assert.Single(result.Weather);
        Assert.Equal(weather, result.Weather[0].Description);
    }

    [Fact]
    public async Task GetWeatherAsync_WhenApiCallFails_ShouldReturnDefaultWeatherModel()
    {
        // Arrange
        var mockHttpMessageHandler = _fixture.Freeze<Mock<HttpMessageHandler>>();

        mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get
                ),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest
            });

        var httpClient = new HttpClient(mockHttpMessageHandler.Object);

        // Act
        var weatherService = new WeatherService(httpClient, _fixture.Create<IConfiguration>());
        var result = await weatherService.GetWeatherAsync("Invalid City");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("", result.Name); 
        Assert.Empty(result.Weather);
    }

    [Theory]
    [MemberData(nameof(WeatherServicesTestData.GetData), parameters: WeatherServicesTestDataSet.ApiDomain, MemberType = typeof(WeatherServicesTestData))]
    public async Task GetWeatherAsync_ShouldCallCorrectUrl(string city, string expectedUrl, string expextedJSON)
    {
        var mockHttpMessageHandler = _fixture.Freeze<Mock<HttpMessageHandler>>();

        mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get &&
                    req.RequestUri != null &&
                    req.RequestUri.ToString() == expectedUrl), 
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(expextedJSON)
            });

        var httpClient = new HttpClient(mockHttpMessageHandler.Object);

        // Act
        var weatherService = new WeatherService(httpClient, _fixture.Create<IConfiguration>());
        await weatherService.GetWeatherAsync(city);

        // Assert
        mockHttpMessageHandler.Protected().Verify(
            "SendAsync",
            Times.Once(),
            ItExpr.Is<HttpRequestMessage>(req =>
                req.Method == HttpMethod.Get &&
                req.RequestUri != null &&
                req.RequestUri.ToString() == expectedUrl),
            ItExpr.IsAny<CancellationToken>()
        );
    }

    [Fact]
    public void Constructor_WhenApiKeyIsMissing_ShouldThrowInvalidOperationException()
    {
        // Arrange
        var mockConfiguration = new Mock<IConfiguration>();
        mockConfiguration.Setup(c => c["WeatherApi:ApiKey"]).Returns((string?)null);

        var httpClient = new HttpClient();

        // Act and Assert
        Assert.Throws<InvalidOperationException>(() =>
            new WeatherService(httpClient, mockConfiguration.Object)
        );
    }


}
