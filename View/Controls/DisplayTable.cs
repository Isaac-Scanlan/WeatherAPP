using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WeatherApp.View.Controls;

public class DisplayTable : DataGrid
{

    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(nameof(Title), typeof(string), typeof(DisplayTable), new PropertyMetadata(string.Empty));

    public string Title
    {
        get { return (string)GetValue(TitleProperty); }
        set { SetValue(TitleProperty, value); }
    }

    static DisplayTable()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(DisplayTable), new FrameworkPropertyMetadata(typeof(DisplayTable)));
    }
}
