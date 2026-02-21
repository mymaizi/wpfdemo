using MaiziWPF.Core;
using MaiziWPF.Services.Application.Contracts;
using MaiziWPF.Services.Domain;
using MaiziWPF.Services.Domain.Shared;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MaiziWPF.Modules.Sys
{
    public class UserListViewModel : PageBindableBase<SysUser,QueryUserInput>
    {
        public ObservableCollection<SysDept> DeptItems { get; set; } = new();
        private readonly ISysDeptService _deptService;
        private readonly ISysUserService _userService;
        public ICommand DeptSelectionCommand { get; }
        public ICommand DeptQueryCommand { get; }
        public UserListViewModel(ISysDeptService deptService, ISysUserService userService)
        {
            _deptService = deptService;
            _userService = userService;
            RegisterQueryFunc(input =>
            {
                return _userService.SelectUserList(input);
            },new QueryUserInput() { PageNumber=1,PageSize=10 });
            DeptSelectionCommand = new DelegateCommand(() =>
            {
               
            });
            DeptQueryCommand = new DelegateCommand(() =>
            {
                SearchDept();
            });
            DeptQueryCommand.Execute(this);
            SearchButtonCommand.Execute(this);
        }
        private void SearchDept()
        {
            DeptItems.Clear();
            var data = _deptService.SelectDeptList(new SysDept()
            {
                DeptName = QueryPageInfo.DeptName
            });
            DeptItems.AddRange(data);
        }
    }
}
