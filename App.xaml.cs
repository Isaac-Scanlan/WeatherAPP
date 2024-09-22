using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using Microsoft.Extensions.Configuration;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IConfiguration Configuration { get; }

        public App()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();

            foreach (var kvp in Configuration.AsEnumerable())
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }

}
