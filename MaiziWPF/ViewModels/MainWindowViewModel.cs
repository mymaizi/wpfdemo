using H.NotifyIcon;
using H.NotifyIcon.Core;
using MaiziWPF.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows;
using System.Windows.Input;

namespace MaiziWPF.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly Window _mainWindow;
        public ICommand ShowWindowCommand { get; }
        public ICommand CloseWindowCommand { get; }
        public MainWindowViewModel()
        {
            _mainWindow = Application.Current.MainWindow as Window;
            _mainWindow.MouseLeftButtonDown += (s, e) =>
            {
                if (e.ButtonState == MouseButtonState.Pressed)
                {
                    _mainWindow.DragMove();
                }
            };
            ShowWindowCommand = new DelegateCommand(() =>
            {
                _mainWindow.Show();
            });
            CloseWindowCommand = new DelegateCommand(() =>
            {
                var tray = _mainWindow.FindName("TrayIcon") as TaskbarIcon;
                if (tray != null)
                {
                    tray.Visibility = Visibility.Collapsed;
                    tray.Dispose();
                }
                _mainWindow.Close();
            });
        }
    }
}
