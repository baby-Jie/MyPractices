using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MyPractises.Converters
{
    [ValueConversion(typeof(bool?), typeof(Visibility))]
    class VisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool visible = false;
            if (bool.TryParse(value.ToString(), out visible))
            {
                if (visible)
                    return Visibility.Visible;
                else
                    return Visibility.Collapsed;
            }
            throw new Exception("value is not bool type");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility? vis;
            if (value is Visibility)
            {
                vis = value as Visibility?;
                if (vis == Visibility.Visible)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
                throw new Exception("something is wrong");
        }
    }
}
