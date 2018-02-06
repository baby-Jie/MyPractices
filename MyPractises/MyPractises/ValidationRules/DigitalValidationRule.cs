using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MyPractises.ValidationRules
{
    class DigitalValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                double val;
                if (double.TryParse(value.ToString(), out val))
                    return new ValidationResult(true, null);
                else
                    return new ValidationResult(false, "error");
            }
            catch (Exception)
            {

                return new ValidationResult(false, "error");
            }
            
            
        }
    }
}
