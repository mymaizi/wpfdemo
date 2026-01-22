using MaiziWPF.Services.Application.Contracts.Users;
using MaiziWPF.Services.Application.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation.Regions;
using System;
using System.Windows.Input;

namespace MaiziWPF.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IUserService _userService;
        public ICommand CloseWindowCommand { get; }
        public ICommand LoginCommand { get; }
        public LoginViewModel(IRegionManager regionManager, IUserService userService)
        {
            _regionManager = regionManager;
            _userService = userService;
            CloseWindowCommand = new DelegateCommand(() =>
            {
                System.Windows.Application.Current.Shutdown();
            });
            LoginCommand = new DelegateCommand(() =>
            {
                _regionManager.RequestNavigate("ContentRegion", "MainView");
            });
        }
    }
}
