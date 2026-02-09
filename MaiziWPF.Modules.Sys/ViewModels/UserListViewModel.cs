using MaiziWPF.Services.Domain;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaiziWPF.Modules.Sys
{
    public class UserListViewModel : BindableBase,INavigationAware
    {
        public List<SysDept> DeptItems { get; }
        private String _searchDeptText;

        public String SearchDeptText
        {
            get { return _searchDeptText; ; }
            set { SetProperty(ref _searchDeptText, value); }
        }
        private SysDept _selectedDept;

        public SysDept SelectedDept
        {
            get { return _selectedDept; ; }
            set { SetProperty(ref _selectedDept,value); }
        }

        public UserListViewModel()
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
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
