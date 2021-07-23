using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPFUI.Converters
{
  [ValueConversion(typeof(bool), typeof(bool))]
  internal class NotConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => !(bool)value;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => !(bool)value;
  }
}