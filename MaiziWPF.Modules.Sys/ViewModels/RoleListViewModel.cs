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
    public class RoleListViewModel : PageBindableBase
    {
        public ObservableCollection<SysRole> RoleItems { get; set; } = new();
        private QueryRoleInput _queryRoleInput;
        public QueryRoleInput QueryRoleInput
        {
            get { return _queryRoleInput; }
            set { SetProperty(ref _queryRoleInput, value); }
        }
        private readonly ISysRoleService _roleService;
        public ICommand SearchButtonCommand { get; }
        public ICommand PrevButtonCommand { get; }
        public ICommand NextButtonCommand { get; }
        public RoleListViewModel(ISysRoleService roleService)
        {
            _roleService = roleService;
            QueryRoleInput = new QueryRoleInput()
            {
                PageSize = 10,
                PageNumber = 1
            };
            SearchButtonCommand = new DelegateCommand(() =>
            {
                QueryRoleInput.PageNumber = 1;
                SearchRole(QueryRoleInput);
            });
            PrevButtonCommand = new DelegateCommand<SysDept>(obj =>
            {
                QueryRoleInput.PageNumber--;
                SearchRole(QueryRoleInput);
            });
            NextButtonCommand = new DelegateCommand<SysDept>(obj =>
            {
                QueryRoleInput.PageNumber++;
                SearchRole(QueryRoleInput);
            });
            SearchRole(QueryRoleInput);
        }
        private void SearchRole(QueryRoleInput queryRoleInput)
        {
            RoleItems.Clear();
            var _list = _roleService.SelectRoleList(queryRoleInput);
            RoleItems.AddRange(_list);
            Count = queryRoleInput.Count;
            PageNumber = queryRoleInput.PageNumber;
            PageSize = queryRoleInput.PageSize;
        }
    }
}
