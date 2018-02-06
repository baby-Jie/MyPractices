using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MyPractises.Converters
{
    class EnableMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {

            try
            {
                string name = values[0].ToString();
                string pass = values[1].ToString();
                string passAgain = values[2].ToString();

                if (!pass.Equals(passAgain))
                    return false;
                if (values.Any((obj) => string.IsNullOrWhiteSpace(obj.ToString())))
                    return false;
                return true;
            }
            catch (Exception)
            {

                throw;
            }

            throw new NotImplementedException();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
