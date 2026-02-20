using MaiziWPF.Core;
using MaiziWPF.Services.Application.Contracts;
using MaiziWPF.Services.Domain;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls.Primitives;

namespace MaiziWPF.Modules.Sys
{
    public class DeptListViewModel : PageBindableBase
    {
        public ObservableCollection<SysDept> DeptItems { get; set; } = new();
        private string _deptName;
        public string DeptName { get => _deptName; set => SetProperty(ref _deptName, value); }
        private string _status;
        public string Status { get => _status; set => SetProperty(ref _status, value); }

        private readonly ISysDeptService _deptService;

        public DeptListViewModel(ISysDeptService deptService)
        {
            _deptService = deptService;
            SearchButtonCommand = new DelegateCommand(() =>
            {
                SearchDept();
            });
            SearchDept();
        }
        private void SearchDept()
        {
            DeptItems.Clear();
            var _list = _deptService.SelectDeptList(new SysDept()
            {
                DeptName = DeptName,
                Status = Status,
            });
            DeptItems.AddRange(_list);
        }
    }
}
