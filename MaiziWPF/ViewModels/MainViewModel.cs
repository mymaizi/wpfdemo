using MaiziWPF.Core;
using MaiziWPF.Services.Application.Contracts;
using MaiziWPF.Services.Domain;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Navigation.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MaiziWPF.ViewModels
{
    public class MainViewModel : BindableBase,INavigationAware
    {
        private readonly ISysMenuService _menuService;
        private readonly Window _mainWindow;
        private readonly IRegionManager _regionManager;
        private String _maxsizeIcon = "Maximize";
        public ICommand CloseWindowCommand { get; }
        public ICommand MinimizeWindowCommand { get; }
        public ICommand MaximizeWindowCommand { get; }
        public ICommand CloseTabCommand { get; }
        public ICommand MenuSelectionCommand { get; }
        public List<SysMenu> MenuItems { get; }
        public object _selectedItem;
        public object SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
        }
        public SysMenu _tabMenu;
        public SysMenu TabMenu
        {
            get { return _tabMenu; }
            set { SetProperty(ref _tabMenu, value); }
        }

        public String MaxsizeIcon
        {
            get { return _maxsizeIcon; }
            set { SetProperty(ref _maxsizeIcon, value); }
        }
     
        public MainViewModel(IRegionManager regionManager, IContainerProvider containerProvider, ISysMenuService menuService)
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
            CloseTabCommand = new DelegateCommand<SysMenu>(menu =>
            {
                var tabRegion = _regionManager.Regions[RegionNames.TabRegion];
                var currentView = tabRegion.GetView(menu.Component);
                if (currentView != null)
                {
                    tabRegion.Remove(currentView);
                }
            });
            MenuItems = _menuService.SelectMenuTreeAll();
            MenuSelectionCommand = new DelegateCommand<SysMenu>(m =>
            {
                var tabRegion = _regionManager.Regions[RegionNames.TabRegion];
                if (!tabRegion.Views.Any(v => v.GetType().Name == m.Component))
                {
                    _tabMenu = m;
                    tabRegion.Add(m.Component);
                }
                SelectedItem = tabRegion.GetView(m.Component);
            });
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var firstMenu = MenuItems.First();
            if (firstMenu != null)
            {
                _tabMenu = firstMenu;
                _regionManager.Regions[RegionNames.TabRegion].Add(firstMenu.Component);
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
