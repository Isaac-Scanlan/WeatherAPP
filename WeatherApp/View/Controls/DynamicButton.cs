using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WeatherApp.View.Controls;

/// <summary>
/// Custom Control of DynamicButton that is stylised
/// </summary>
public class DynamicButton : Button
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DynamicButton"/> class.
    /// Overrides the default style key property to use <see cref="DynamicButton"/>.
    /// </summary>
    static DynamicButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(DynamicButton), new FrameworkPropertyMetadata(typeof(DynamicButton))
            );
    }
}
