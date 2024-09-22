using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WeatherApp.View.Controls;

/// <summary>
/// Custom Control of DataGrid that is stylised
/// </summary>
public class DisplayTable : DataGrid
{

    /// <summary>
    /// Initializes a new instance of the <see cref="DisplayTable"/> class.
    /// Overrides the default style key property to use <see cref="DisplayTable"/>.
    /// </summary>
    static DisplayTable()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(DisplayTable), new FrameworkPropertyMetadata(typeof(DisplayTable)));
    }
}
