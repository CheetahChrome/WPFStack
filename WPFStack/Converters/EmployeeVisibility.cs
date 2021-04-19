using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using WPFStack.Model;

namespace WPFStack.Converters
{
public class EmployeeVisiblity : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var isVisible = Visibility.Collapsed;

        if (value != null)
            if (value is Employee)
            {
                if (parameter == null) // Does not say string "Reverse"
                    isVisible = Visibility.Visible;
            }
        else // Value is a person
            {
                if (parameter != null) // Does say string "Reverse"
                    isVisible = Visibility.Visible;
            }

        return isVisible;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }
}
}
