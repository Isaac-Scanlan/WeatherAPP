using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WeatherApp.Helpers;

namespace WeatherApp.View.Controls;

/// <summary>
/// Custom Control of TextBox that has a button for clearing text
/// </summary>
public class ClearableTextBox: TextBox
{
    /// <summary>
    /// Gets the command used to clear the text in the <see cref="ClearableTextBox"/>.
    /// </summary>
    public ICommand ClearCommand { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ClearableTextBox"/> class.
    /// Overrides the default style key property to use <see cref="ClearableTextBox"/>.
    /// Also initializes the <see cref="ClearCommand"/> to clear the text.
    /// </summary>
    static ClearableTextBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(ClearableTextBox), new FrameworkPropertyMetadata(typeof(ClearableTextBox))
            );
    }

    public ClearableTextBox()
    {
        ClearCommand = new RelayCommand(ClearText);
    }

    private void ClearText()
    {
        Clear();
    }

}
