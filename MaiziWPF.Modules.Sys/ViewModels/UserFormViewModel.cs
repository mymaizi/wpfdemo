using MaiziWPF.Core.Services;
using MaiziWPF.Services.Domain;
using Prism.Commands;
using Prism.Dialogs;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace MaiziWPF.Modules.Sys
{
    public class UserFormViewModel : BindableBase
    {
        private SysUser  _formUser;
        public SysUser FormUser
        {
            get { return _formUser; }
            set { SetProperty(ref _formUser, value); }
        }
        public ICommand AcceptCommand { get; }
        public ICommand CancelCommand { get; }
        private readonly IDialogHostService _dialogHostService;
        public UserFormViewModel(IDialogHostService dialogHostService)
        {
            _dialogHostService = dialogHostService;
            AcceptCommand = new DelegateCommand(() =>
            {

            });
            CancelCommand = new DelegateCommand(() =>
            {
                dialogHostService.CloseDialogAsync();
            });
        }
    }
}
