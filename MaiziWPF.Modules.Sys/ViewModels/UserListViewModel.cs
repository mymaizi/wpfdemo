using MaiziWPF.Services.Application.Contracts;
using MaiziWPF.Services.Domain;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace MaiziWPF.Modules.Sys
{
    public class UserListViewModel : BindableBase
    {
        public List<SysDept> DeptItems { get; }
        private String _searchDeptText;

        public String SearchDeptText
        {
            get { return _searchDeptText; ; }
            set { SetProperty(ref _searchDeptText, value); }
        }
        private DateTime _searchStartDate;

        public DateTime SearchStartDate
        {
            get { return _searchStartDate; ; }
            set { SetProperty(ref _searchStartDate, value); }
        }
        private DateTime _searchEndDate;

        public DateTime SearchEndDate
        {
            get { return _searchEndDate; ; }
            set { SetProperty(ref _searchEndDate, value); }
        }
        private readonly ISysDeptService _deptService;
        public ICommand DeptSelectionCommand { get; }
        public ICommand SearchButtonCommand { get; }
        public UserListViewModel(ISysDeptService deptService)
        {
            _deptService = deptService;
            DeptItems = _deptService.SelectDeptTreeList(new SysDept());
            DeptSelectionCommand = new DelegateCommand<SysDept>(obj =>
            {

            });
            SearchButtonCommand = new DelegateCommand(() =>
            {
               
            });
        }
    }
}
