using MaiziWPF.Modules.System;
using MaiziWPF.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prism.Container.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Navigation.Regions;
using System;
using System.Windows;
using Volo.Abp;

namespace MaiziWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LoginView>();
            containerRegistry.RegisterForNavigation<MainView>();
        }
        protected override void InitializeShell(Window shell)
        {
            base.InitializeShell(shell);
            var regionManager = Container.Resolve<IRegionManager>();
            regionManager.RequestNavigate("ContentRegion", "LoginView");
        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<SystemModule>();
        }
        protected override IContainerExtension CreateContainerExtension()
        {
            var containerExtension = base.CreateContainerExtension() as DryIocContainerExtension;
            var app= AbpApplicationFactory.Create<MaiziWPFModule>(options =>
            {
                //Configure your application options here
                //var builder = new ConfigurationBuilder();
                //builder.AddJsonFile("appsettings.json", optional: false);
                //options.Services.ReplaceConfiguration(builder.Build());
                //or
                //IConfigurationRoot configuration = builder.Build();
                //options.Services.Configure<T>(configuration.GetSection(""));
            });
            app.Initialize();
            containerExtension.Populate(app.Services);
            return containerExtension;
        }
    }
}
