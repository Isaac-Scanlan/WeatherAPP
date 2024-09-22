using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using Microsoft.Extensions.Configuration;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for <c>App.xaml</c>.
    /// This class handles application-level events and configuration initialization.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Gets the application configuration loaded from <c>appsettings.Local.json</c>.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// Loads the application configuration from the <c>appsettings.Local.json</c> file.
        /// </summary>
        public App()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }
    }


}
