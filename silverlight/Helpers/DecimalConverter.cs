using System;
using System.Globalization;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Epiworx.Silverlight.Helpers
{
    public class DecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            // Retrieve the format string and use it to format the value.
            var formatString = parameter as string;

            if (!string.IsNullOrEmpty(formatString))
            {
                formatString = "{0:" + formatString + "}";
                return string.Format(culture, formatString, value);
            }

            // If the format string is null or empty, simply call ToString()
            // on the value.
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

