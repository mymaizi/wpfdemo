using MaiziWPF.Services.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace MaiziWPF.Core
{
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string _parameter = string.IsNullOrEmpty((string)parameter) ? "yyyy-MM-dd" : (string)parameter;
            return ((DateTime)value).ToString(_parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
