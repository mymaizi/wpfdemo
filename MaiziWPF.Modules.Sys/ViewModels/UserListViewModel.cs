using MaiziWPF.Core;
using MaiziWPF.Core.Services;
using MaiziWPF.Services.Application.Contracts;
using MaiziWPF.Services.Domain;
using MaiziWPF.Services.Domain.Shared;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Dialogs;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
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
        private readonly IContainerProvider _containerProvider;
        private readonly IDialogHostService _dialogHostService;

        public UserListViewModel(ISysDeptService deptService, ISysUserService userService,IContainerProvider containerProvider, IDialogHostService dialogHostService)
        {
            _deptService = deptService;
            _userService = userService;
            _containerProvider = containerProvider;
            _dialogHostService = dialogHostService;
            this.AddOrEditButtonCommand = new DelegateCommand(() =>
            {
                var view = _containerProvider.Resolve<UserFormView>();
                var model = _containerProvider.Resolve<UserFormViewModel>();
                view.DataContext= model;
                _dialogHostService.ShowDialogAsync(view, autoClose: false);
            });
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
