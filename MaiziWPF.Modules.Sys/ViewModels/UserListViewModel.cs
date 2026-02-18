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
    public class UserListViewModel : PageBindableBase
    {
        public ObservableCollection<SysDept> DeptItems { get; set; } = new();
        public ObservableCollection<SysUser> UserItems { get; set; } = new();
        private QueryUserInput _queryUserInput;
        public QueryUserInput QueryUserInput
        {
            get { return _queryUserInput;  }
            set { SetProperty(ref _queryUserInput, value); }
        }
        private readonly ISysDeptService _deptService;
        private readonly ISysUserService _userService;
        public ICommand DeptSelectionCommand { get; }
        public ICommand SearchButtonCommand { get; }
        public ICommand PrevButtonCommand { get; }
        public ICommand NextButtonCommand { get; }
        public UserListViewModel(ISysDeptService deptService, ISysUserService userService)
        {
            _deptService = deptService;
            _userService = userService;
            QueryUserInput = new QueryUserInput() { 
                PageSize = 10,
                PageNumber = 1
            };
            DeptSelectionCommand = new DelegateCommand<SysDept>(obj =>
            {

            });
            SearchButtonCommand = new DelegateCommand(() =>
            {
                QueryUserInput.PageNumber = 1;
                SearchUser(QueryUserInput);
            });
            PrevButtonCommand = new DelegateCommand(() =>
            {
                QueryUserInput.PageNumber--;
                SearchUser(QueryUserInput);
            });
            NextButtonCommand = new DelegateCommand(() =>
            {
                QueryUserInput.PageNumber++;
                SearchUser(QueryUserInput);
            });
            SearchDept(QueryUserInput);
            SearchUser(QueryUserInput);
        }
        private void SearchUser(QueryUserInput queryUserInput)
        {
            UserItems.Clear();
            var _list = _userService.SelectUserList(queryUserInput);
            UserItems.AddRange(_list);
            Count = queryUserInput.Count;
            PageNumber = queryUserInput.PageNumber;
            PageSize = queryUserInput.PageSize;
        }
        private void SearchDept(QueryUserInput queryUserInput)
        {
            DeptItems.Clear();
            var _list = _deptService.SelectDeptTreeList(new SysDept()
            {
                DeptName = queryUserInput.DeptName,
            });
            DeptItems.AddRange(_list);
        }
    }
}
