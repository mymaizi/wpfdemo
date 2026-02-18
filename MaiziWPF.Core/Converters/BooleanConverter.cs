using MaiziWPF.Services.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace MaiziWPF.Core
{
    public class BooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (string)value=="1";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
           return null;
        }
    }
}
