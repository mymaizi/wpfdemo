using MaiziWPF.Services.Application.Contracts;
using System.Windows;
using System.Windows.Controls;
using Prism.Ioc;
using System.Collections.Generic;
using MaiziWPF.Services.Domain;
using System.Linq;

namespace MaiziWPF.Core
{
    public class DataDictAssist
    {
        public static readonly DependencyProperty DataDictProperty =
          DependencyProperty.RegisterAttached("Type", typeof(string), typeof(DataDictAssist),
              new FrameworkPropertyMetadata(string.Empty, OnTypePropertyChanged));
        public static string GetType(DependencyObject obj)
        {
            return (string)obj.GetValue(DataDictProperty);
        }

        public static void SetType(DependencyObject obj, string value)
        {
            obj.SetValue(DataDictProperty, value);
        }

        private static void OnTypePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            List<SysDictData> dictDatas=new();
            var container = ContainerLocator.Container;
            if (container != null)
            {
                var sysDictService = container.Resolve<ISysDictService>();
                dictDatas= sysDictService.SelectDictDataByType((string)e.NewValue);
            }
            if (d is ComboBox cb)
            {
                cb.ItemsSource = dictDatas;
            }
        }
    }
}
