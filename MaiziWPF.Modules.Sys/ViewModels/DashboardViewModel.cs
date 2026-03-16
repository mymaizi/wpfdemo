using MaiziWPF.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaiziWPF.Modules.Sys
{
    public class DashboardViewModel : BindableBase,ITabItemInfo
    {
        public string Header { get; set; }
        public string Component { get; set; }
        private readonly IRegionManager _regionManager;
        public DashboardViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
    }
}
