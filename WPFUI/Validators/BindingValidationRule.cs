using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFUI.Validators
{
  internal class BindingValidationRule : ValidationRule
  {
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
      return value is string s && string.IsNullOrEmpty(s.Trim()) ? new ValidationResult(false, "") : ValidationResult.ValidResult;
    }
  }
}