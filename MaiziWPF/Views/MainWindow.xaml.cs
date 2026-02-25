using MaterialDesignThemes.Wpf;
using System.Windows;

namespace MaiziWPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DialogHost GlobalDialogInstance { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            GlobalDialogInstance = RootDialog; 
        }
    }
}
