using MaiziWPF.Services.Domain;
using System;
using System.Globalization;
using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Data;

namespace MaiziWPF.Core
{
    public class TabItemVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is SysMenu menu && menu.Component== (string)parameter) ?
                Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
