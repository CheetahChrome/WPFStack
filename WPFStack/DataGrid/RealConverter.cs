using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPFStack.DataGrid
{
    public class RealConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) 
            => (value != null) ? ((double) value).ToString() : "0.0";

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
            => (value != null) ? double.Parse((string) value) : 0.0;
    }
}
