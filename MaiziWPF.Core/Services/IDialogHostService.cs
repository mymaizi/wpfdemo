using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MaiziWPF.Core.Services
{
    public interface IDialogHostService
    {
        Task ShowDialogAsync(object content, bool autoClose = true, int autoCloseTime = 2000, Action onDialogClosed = null, bool isShadow = true, string identifier = "RootDialog");
        Task AlertAsync(string message,Action onAlertClosed = null, string identifier = "RootDialog");
        Task CloseDialogAsync(Action onDialogClosed = null,string identifier = "RootDialog");
    }
}
