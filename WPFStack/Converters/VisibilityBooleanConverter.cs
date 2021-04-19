using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WPFStack.Converters
{
    public class VisibilityBooleanConverter : IValueConverter
    {

        public object Convert( object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture )
        {
            var result = Visibility.Collapsed;

            try
            {
                if (value is bool)
                {
                    bool unboxedValue = (bool)value;

                    if (unboxedValue == true)
                        result = Visibility.Visible;
                }
                else
                {
                    if (value is Visibility) // Return true or false if a visbility is checked.
                    {
                        return (Visibility)value == Visibility.Visible; 
                    }
                }

            }
            catch (Exception) { }

            return result;
        }

        public object ConvertBack( object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture )
        {
            if (targetType.Equals(typeof(Visibility)))
            {
                return (bool)value ? Visibility.Visible : Visibility.Collapsed;
            }
            
            return !((bool)value);
        }
    }
}
