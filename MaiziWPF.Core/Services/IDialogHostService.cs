using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MaiziWPF.Core.Services
{
    public interface IDialogHostService
    {
        Task ShowDialogAsync(object content, string identifier = "RootDialog");
        void CloseDialogAsync(string identifier = "RootDialog");
    }
}
