using MaiziWPF.Services.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Windows.Data;
using System.Windows.Documents;

namespace MaiziWPF.Core
{
    public class ListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IEnumerable _value && !_value.Cast<object>().Any())
            {
                return null;
            }
            var sb = ((IEnumerable)value).Cast<object>().Select(item =>
            {
                var property = TypeDescriptor.GetProperties(item)[(string)parameter];
                return property?.GetValue(item)?.ToString() ?? "";

            }).ToList();
            return string.Join('|', sb);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
