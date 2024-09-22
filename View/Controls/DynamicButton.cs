using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WeatherApp.View.Controls;

public class DynamicButton : Button
{
    static DynamicButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(DynamicButton), new FrameworkPropertyMetadata(typeof(DynamicButton))
            );
    }

}
