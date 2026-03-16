using MaiziWPF.Core;
using MaiziWPF.Services.Application.Contracts;
using MaiziWPF.Services.Domain;
using MaiziWPF.Services.Domain.Shared;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Input;

namespace MaiziWPF.Modules.Sys
{
    public class MenuListViewModel : PageBindableBase<SysMenu, QueryMenuInput>
    {
        public ObservableCollection<SysMenu> MenuItems { get; set; } = new();
        private string _menuName;
        public string MenuName { get => _menuName; set => SetProperty(ref _menuName, value); }
        private string _status;
        public string Status { get => _status; set => SetProperty(ref _status, value); }
        public ICommand SearchButtonCommand { get; }
        private readonly ISysMenuService _menuService;

        public MenuListViewModel(ISysMenuService menuService)
        {
            _menuService = menuService;
            SearchButtonCommand = new DelegateCommand(() =>
            {
                SearchMenu();
            });
            SearchButtonCommand.Execute(this);
        }
        private void SearchMenu()
        {
            MenuItems.Clear();
            var _list = _menuService.SelectMenuList(new SysMenu()
            {
                MenuName = MenuName,
                Status = Status,
            }, 1);
            MenuItems.AddRange(_list);
        }
    }
}
