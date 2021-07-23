using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPFUI.Converters
{
  [ValueConversion(typeof(string), typeof(bool))]
  internal class IsNullOrEmpty : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => string.IsNullOrEmpty(value as string);

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
  }
}