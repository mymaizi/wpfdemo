using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Input;

namespace MaiziWPF.Core
{
    public class FormBindableBase: BindableBase
    {
        public ICommand AcceptCommand { get; set; }
        public ICommand CancelCommand { get; }
        private readonly IDialogHostService _dialogHostService;
        public Action OnSaveSuccessCallback { get; set; }
        public FormBindableBase(IDialogHostService dialogHostService)
        {
            _dialogHostService = dialogHostService;
            CancelCommand = new DelegateCommand(() =>
            {
                _dialogHostService.CloseDialogAsync();
            });
        }
    }
}
