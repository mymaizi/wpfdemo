using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MaiziWPF.Core;

namespace MaiziWPF.Core
{
    public interface IDialogHostService
    {
        Task ShowDialogAsync(object content, bool autoClose = true, int autoCloseTime = 2000, Action onDialogClosed = null, bool isShadow = true, string identifier = "RootDialog");
        Task<bool> ConfirmAsync(string message, string title = "确认", string confirmButtonText = "确定", string cancelButtonText = "取消", string identifier = "RootDialog");
        Task AlertAsync(string message, Action onAlertClosed = null, string identifier = "RootDialog");
        Task AlertAsync(string message, AlertType alertType, Action onAlertClosed = null, string identifier = "RootDialog");
        Task CloseDialogAsync(Action onAlertClosed = null,string identifier = "RootDialog");
    }
}
