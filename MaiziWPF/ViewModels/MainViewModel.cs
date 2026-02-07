using FreeSql.DataAnnotations;
using MaiziWPF.Core;
using MaiziWPF.Services.Application.Contracts;
using MaiziWPF.Services.Domain;
using MaiziWPF.Views;
using Prism.Commands;
using Prism.Common;
using Prism.Mvvm;
using Prism.Navigation.Regions;
using Serilog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace MaiziWPF.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly ISysMenuService _menuService;
        private readonly Window _mainWindow;
        private readonly IRegionManager _regionManager;
        private String _maxsizeIcon = "Maximize";
        public ObservableCollection<TabItem> Tabs { get; }
        private TabItem _selectedTab;
        public ICommand CloseWindowCommand { get; }
        public ICommand MinimizeWindowCommand { get; }
        public ICommand MaximizeWindowCommand { get; }
        public ICommand CloseTabCommand { get; }
        public ICommand MenuSelectionCommand { get; }
        public List<SysMenu> MenuItems { get; }
        public SysMenu _ss;

        public SysMenu ss
        {
            get { return _ss; }
            set { SetProperty(ref _ss, value); }
        }

        public String MaxsizeIcon
        {
            get { return _maxsizeIcon; }
            set { SetProperty(ref _maxsizeIcon, value); }
        }
        public TabItem SelectedTab
        {
            get { return _selectedTab; }
            set { SetProperty(ref _selectedTab, value); }
        }

        public MainViewModel(IRegionManager regionManager, ISysMenuService menuService)
        {
            _menuService = menuService;
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
                _mainWindow?.WindowState = _mainWindow?.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
                MaxsizeIcon = _mainWindow?.WindowState == WindowState.Maximized ? "WindowMaximize" : "Maximize";
            });
            CloseTabCommand = new DelegateCommand<TabItem>((tab) =>
            {
                if (tab != null && Tabs.Contains(tab))
                {
                    Tabs.Remove(tab);
                }
            });

            MenuItems = _menuService.SelectMenuTreeAll();
            var firstMenu=  MenuItems.First();
            var firstMenuView = regionManager.Regions[nameof(RegionNames.ContentRegion)].GetView(firstMenu.Component);
            Tabs = new ObservableCollection<TabItem>
            {
               new TabItem()
                {
                    Content = firstMenuView,
                    Header = firstMenu.MenuName,
                }
            };
            SelectedTab = Tabs[0];

            MenuSelectionCommand = new DelegateCommand<SysMenu>(m =>
            {
                if (Tabs.Any(a => a.Header == m.MenuName))
                {

                }
                else if (m.Component != null)
                {
                    var view = regionManager.Regions[nameof(RegionNames.ContentRegion)].GetView(m.Component);
                    var index = Tabs.Count;
                    Tabs.Add(new TabItem()
                    {
                        Content = view,
                        Header = m.MenuName,
                        TabIndex = index++
                    });
                }
            });
        }
    }
}
