using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using static MaterialDesignThemes.Wpf.Theme;

namespace WpfApp1
{


    public class TabItemModel
    {
        public string Header { get; set; }
        public Frame Content { get; set; }
        public int TabIndex { get; set; }
    }
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<TabItemModel> Tabs { get; }
        private TabItemModel _selectedTab;
        public TabItemModel SelectedTab
        {
            get => _selectedTab;
            set
            {
                _selectedTab = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand CloseTabCommand { get; }
        public ICommand AddTabCommand { get; }

        public MainWindowViewModel()
        {
            Tabs = new ObservableCollection<TabItemModel>
        {
            new TabItemModel { Header = "TAB 1",TabIndex=0, Content = new Frame(){
                Source= new Uri("TabPage1.xaml", UriKind.Relative)
            } },
            new TabItemModel { Header = "TAB 2",TabIndex=1, Content =new Frame(){
                Source= new Uri("TabPage2.xaml?data=TAB 2", UriKind.Relative)
            } }

        };
            SelectedTab = Tabs[0];
            CloseTabCommand = new RelayCommand<TabItemModel>(tab => Tabs.Remove(tab));
            AddTabCommand = new RelayCommand<object>(length =>
            {
                if ((double)length - 402 < (Tabs.Count + 1) * 100)
                {
                    Tabs.RemoveAt(Tabs.Count - 1);
                }
                int newIndex = Tabs.Count;
                var tab = new TabItemModel
                {
                    Header = $"TAB {newIndex + 1}",
                    TabIndex = newIndex,
                    Content = new Frame()
                    {
                        Source = new Uri("TabPage2.xaml?data=" + $"TAB {newIndex + 1}", UriKind.Relative)
                    }
                };
                Tabs.Insert(1, tab);
                SelectedTab = tab;

            });

        }

    }
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Predicate<T> _canExecute;
        public event EventHandler? CanExecuteChanged;
        public RelayCommand(Action<T> execute, Predicate<T> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }
        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute((T)parameter);
        }

        public void Execute(object? parameter)
        {
            _execute((T)parameter);
        }
    }
    public class WidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value - 402;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is TabItemModel modelValue && modelValue.TabIndex != 0) ?
                Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
