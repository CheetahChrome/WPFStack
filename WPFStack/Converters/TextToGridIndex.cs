using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPFStack.Converters
{
public class TextToGridIndex : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int result = -1; // Default to no choice

            if (value != null)
            {
                 
                var selection = value.ToString();

                if (string.IsNullOrWhiteSpace(selection) == false)
                    int.TryParse(selection, out result);
            }

            return result;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
