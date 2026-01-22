using MaiziWPF.OtherModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MaiziWPF.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly Window _mainWindow;
        private readonly IRegionManager _regionManager;
        private String _maxsizeIcon = "Maximize";
        public ObservableCollection<TabItemModel> Tabs { get; }
        private TabItemModel _selectedTab;
        public ICommand CloseWindowCommand { get; }
        public ICommand MinimizeWindowCommand { get; }
        public ICommand MaximizeWindowCommand { get; }
        public ICommand CloseTabCommand { get; }
   
        public String MaxsizeIcon
        {
            get { return _maxsizeIcon; }
            set { SetProperty(ref _maxsizeIcon, value); }
        }
        public TabItemModel SelectedTab
        {
            get { return _selectedTab; }
            set { SetProperty(ref _selectedTab, value); }
        }
        public MainViewModel(IRegionManager regionManager)
        {
            _mainWindow = Application.Current.MainWindow as Window;
            _regionManager = regionManager;
            CloseWindowCommand = new DelegateCommand(() =>
            {
                _mainWindow.Hide();
            });
            MinimizeWindowCommand = new DelegateCommand(() =>
            {
                _mainWindow?.WindowState = WindowState.Minimized;
            });
            MaximizeWindowCommand = new DelegateCommand(() =>
            {
                _mainWindow?.WindowState= _mainWindow?.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
                MaxsizeIcon = _mainWindow?.WindowState == WindowState.Maximized ? "WindowMaximize" : "Maximize";
            });
            CloseTabCommand = new DelegateCommand<TabItemModel>((tab) =>
            {
                if (tab != null && Tabs.Contains(tab))
                {
                    Tabs.Remove(tab);
                }
            });
            Tabs = new ObservableCollection<TabItemModel>
            {
                new TabItemModel { Header = "TAB 1",TabIndex=0},
                new TabItemModel { Header = "TAB 2",TabIndex=1}
            };
            SelectedTab = Tabs[0];
        }
    }
}
