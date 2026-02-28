using MaiziWPF.Core.Services;
using MaiziWPF.Views;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.Hosting;
using Prism.Dialogs;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MaiziWPF.Services
{
    public class DialogHostService : IDialogHostService
    {
        public async Task ShowDialogAsync(object content,bool autoClose = true,int autoCloseTime = 2000,Action onDialogClosed = null,bool isShadow = true,string identifier = "RootDialog")
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content), "弹窗内容不能为空");
            }
            if (autoCloseTime < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(autoCloseTime), "自动关闭时间不能为负数");
            }
            if (string.IsNullOrWhiteSpace(identifier))
            {
                throw new ArgumentException("弹窗标识不能为空", nameof(identifier));
            }

            Brush overlayBrush = System.Windows.Application.Current.TryFindResource("MaterialDesignShadowBrush") as Brush
                                 ?? new SolidColorBrush(Color.FromArgb(128, 0, 0, 0));
            if (autoClose)
            {
                _ = StartAutoCloseTask(autoCloseTime, identifier, onDialogClosed);
            }
          
            DialogOpenedEventHandler openedHandler = (s, e) =>
            {
                if (isShadow && s is DialogHost dialogHost)
                {
                    dialogHost.OverlayBackground = overlayBrush;
                }
            };
            await DialogHost.Show(content, identifier, openedHandler);
        }

        private async Task StartAutoCloseTask(int delayMilliseconds, string identifier, Action onDialogClosed)
        {
            await Task.Delay(delayMilliseconds);
            await CloseDialogAsync(onDialogClosed,identifier);
        }

        public async Task CloseDialogAsync(Action onDialogClosed = null,string identifier = "RootDialog")
        {
            await System.Windows.Application.Current.Dispatcher.InvokeAsync(() =>
            {
                DialogHost.Close(identifier);
                if (onDialogClosed != null) onDialogClosed();
            });
        }

        public async Task AlertAsync(string message, Action onAlertClosed = null, string identifier = "RootDialog")
        {
            var content = new TextBlock
            {
                Text = message,
                Margin = new Thickness(20),
                TextWrapping = TextWrapping.WrapWithOverflow,
                FontSize = 16
            };
            _ = ShowDialogAsync(content, isShadow: false, onDialogClosed: onAlertClosed, identifier:identifier);
        }
    }
}
