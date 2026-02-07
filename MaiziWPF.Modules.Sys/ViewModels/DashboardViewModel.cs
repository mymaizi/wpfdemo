using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaiziWPF.Modules.Sys
{
    public class DashboardViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        public DashboardViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
    }
}
