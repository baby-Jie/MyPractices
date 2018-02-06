using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MyPractises.Converters
{
    class GroupRangeConverter : IValueConverter
    {
        private int interval;

        public int Interval
        {
            get { return interval; }
            set { interval = value; }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int num = (int)double.Parse(value.ToString());
            int interger = num / interval;

            return $"score from {interger*interval} to {(interger+1)*interval}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
