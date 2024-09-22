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

public class ClearableTextBox: TextBox
{
    public ICommand ClearCommand { get; }


    public ClearableTextBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(ClearableTextBox), new FrameworkPropertyMetadata(typeof(ClearableTextBox))
            );
        ClearCommand = new RelayCommand(ClearText);
    }

    // This method will be executed when the button is clicked
    private void ClearText()
    {
        Clear();  // Clear the text in the TextBox
    }



}
