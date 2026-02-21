using Prism.Commands;
using Prism.Dialogs;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaiziWPF.Modules.Sys
{
    public class UserFormViewModel : BindableBase, IDialogAware
    {
        public DialogCloseListener RequestClose{ get; }
        public UserFormViewModel()
        {
        }
    
        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }
    }
}
