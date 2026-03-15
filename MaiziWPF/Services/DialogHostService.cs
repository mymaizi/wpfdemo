using MaiziWPF.Core.Services;
using MaiziWPF.Core;
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
            await AlertAsync(message, AlertType.Info, onAlertClosed, identifier);
        }

        public async Task AlertAsync(string message, AlertType alertType, Action onAlertClosed = null, string identifier = "RootDialog")
        {
            var stackPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(20)
            };

            PackIconKind iconKind;
            Brush iconColor;

            switch (alertType)
            {
                case AlertType.Error:
                    iconKind = PackIconKind.Error;
                    iconColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D32F2F")); // 深红色
                    break;
                case AlertType.Warning:
                    iconKind = PackIconKind.Warning;
                    iconColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA000")); // 琥珀色
                    break;
                case AlertType.Info:
                default:
                    iconKind = PackIconKind.Information;
                    iconColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00796B")); // 与主题匹配的Teal色
                    break;
            }

            var icon = new PackIcon
            {
                Kind = iconKind,
                Width = 24,
                Height = 24,
                Foreground = iconColor,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 10, 0)
            };

            var textBlock = new TextBlock
            {
                Text = message,
                TextWrapping = TextWrapping.WrapWithOverflow,
                FontSize = 16,
                VerticalAlignment = VerticalAlignment.Center
            };

            stackPanel.Children.Add(icon);
            stackPanel.Children.Add(textBlock);

            _ = ShowDialogAsync(stackPanel, isShadow: false, onDialogClosed: onAlertClosed, identifier: identifier);
        }
    }
}
