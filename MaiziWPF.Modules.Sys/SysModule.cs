using MaiziWPF.Core;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Navigation.Regions;

namespace MaiziWPF.Modules.Sys
{
    public class SysModule : IModule
    {
        private readonly IRegionManager _regionManager;
        public SysModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.Regions[RegionNames.ContentRegion].Add(typeof(DashboardView), nameof(DashboardView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<DashboardView>();
        }
    }
}