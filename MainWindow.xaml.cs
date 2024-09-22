using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WeatherApp.ViewModels;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for <see cref="MainWindow"/>.
    /// This is the main window of the application and sets up the data context for the view.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// Sets up the <see cref="MainViewModel"/> as the data context for the window.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // Retrieves the configuration from the application and passes it to the MainViewModel
            var configuration = ((App)Application.Current).Configuration;

            // Sets the data context for data binding to the MainViewModel
            DataContext = new MainViewModel(configuration);
        }
    }

}