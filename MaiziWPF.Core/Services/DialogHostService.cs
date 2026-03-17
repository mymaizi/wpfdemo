using MaterialDesignThemes.Wpf;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MaiziWPF.Core
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

        public async Task<bool> ConfirmAsync(string message, string title = "确认", string confirmButtonText = "确定", string cancelButtonText = "取消", string identifier = "RootDialog")
        {
            var tcs = new TaskCompletionSource<bool>();
            
            var grid = new Grid
            {
                Width = 300,
                Height = 150,
                Margin = new Thickness(20)
            };
            
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            
            // 消息文本
            var messageTextBlock = new TextBlock
            {
                Text = message,
                TextWrapping = TextWrapping.Wrap,
                FontSize = 16,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                TextAlignment = TextAlignment.Center
            };
            Grid.SetRow(messageTextBlock, 0);
            grid.Children.Add(messageTextBlock);
            
            // 按钮面板
            var buttonPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 10, 0, 0)
            };
            Grid.SetRow(buttonPanel, 1);
            grid.Children.Add(buttonPanel);
            
            // 确认按钮
            var confirmButton = new Button
            {
                Content = confirmButtonText,
                Width = 80,
                Height = 36,
                Margin = new Thickness(0, 0, 10, 0),
                Style = (Style)System.Windows.Application.Current.TryFindResource("MaterialDesignFlatButton")
            };
            confirmButton.Click += async (s, e) =>
            {
                tcs.SetResult(true);
                await CloseDialogAsync(null, identifier);
            };
            buttonPanel.Children.Add(confirmButton);
            
            // 取消按钮
            var cancelButton = new Button
            {
                Content = cancelButtonText,
                Width = 80,
                Height = 36,
                Style = (Style)System.Windows.Application.Current.TryFindResource("MaterialDesignFlatButton")
            };
            cancelButton.Click += async (s, e) =>
            {
                tcs.SetResult(false);
                await CloseDialogAsync(null, identifier);
            };
            buttonPanel.Children.Add(cancelButton);
            
            await ShowDialogAsync(grid, false, 0, null, true, identifier);
            
            return await tcs.Task;
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

        public async Task CloseDialogAsync(Action onDialogClosed = null, string identifier = "RootDialog")
        {
            await System.Windows.Application.Current.Dispatcher.InvokeAsync(() =>
            {
                DialogHost.Close(identifier);
                if (onDialogClosed != null) onDialogClosed();
            });
        }
    }
}
