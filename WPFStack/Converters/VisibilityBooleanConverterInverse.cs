using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WPFStack.Converters
{
    public class VisibilityBooleanConverterInverse : IValueConverter
    {

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var result = Visibility.Collapsed;

            try
            {
                bool unboxedValue = !(bool)value;

                if (unboxedValue == true)
                    result = Visibility.Visible;

            }
            catch (Exception) { result = Visibility.Collapsed; }

            return result;
        }

        public object ConvertBack( object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture )
        {
            return !((bool)value);
        }
    }
}
