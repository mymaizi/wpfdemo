using MaiziWPF.Core.Services;
using MaiziWPF.Views;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MaiziWPF.Services
{
    public class DialogHostService : IDialogHostService
    {
        public void CloseDialogAsync(string identifier = "RootDialog")
        {
            if (MainWindow.GlobalDialogInstance != null)
            {
                if (MainWindow.GlobalDialogInstance.IsOpen)
                {
                     MainWindow.GlobalDialogInstance.CurrentSession.Close();
                }
            }
            else
            {
                if (DialogHost.IsDialogOpen(identifier))
                {
                    DialogHost.Close(identifier);
                }
            }
        }

        public async Task ShowDialogAsync(object content, string identifier = "RootDialog")
        {
            Brush overlayBrush =  System.Windows.Application.Current.TryFindResource("MaterialDesignShadowBrush") as Brush;
            if (MainWindow.GlobalDialogInstance != null)
            {
                var dialog = MainWindow.GlobalDialogInstance;
                dialog.OverlayBackground = overlayBrush;
                await dialog.ShowDialog(content);
            }
            else
            {
                await DialogHost.Show(content, identifier, new DialogOpenedEventHandler((s, e) =>
                {
                    (s as DialogHost).OverlayBackground = overlayBrush;
                }));
            }
        }
    }
}
