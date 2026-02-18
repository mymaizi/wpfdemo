using FreeSql.Internal.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MaiziWPF.Core
{
    /// <summary>
    /// PageControl.xaml 的交互逻辑
    /// </summary>
    public partial class PageControl : UserControl
    {
        public static readonly DependencyProperty PrevCommandProperty =
        DependencyProperty.Register(
           "PrevCommand",
           typeof(ICommand),
           typeof(PageControl),
           new FrameworkPropertyMetadata(null));

        public ICommand PrevCommand
        {
            get => (ICommand)GetValue(PrevCommandProperty);
            set => SetValue(PrevCommandProperty, value);
        }
        public static readonly DependencyProperty NextCommandProperty =
        DependencyProperty.Register(
           "NextCommand",
           typeof(ICommand),
           typeof(PageControl),
           new FrameworkPropertyMetadata(null));

        public ICommand NextCommand
        {
            get => (ICommand)GetValue(NextCommandProperty);
            set => SetValue(NextCommandProperty, value);
        }
        public static readonly DependencyProperty PageNumberProperty =
          DependencyProperty.Register(
          "PageNumber",
          typeof(int),
          typeof(PageControl),
          new FrameworkPropertyMetadata(0, OnPageNumberPropertyChanged));

        public int PageNumber
        {
            get => (int)GetValue(PageNumberProperty);
            set => SetValue(PageNumberProperty, value);
        }
        public static readonly DependencyProperty PageSizeProperty =
           DependencyProperty.Register(
           "PageSize",
           typeof(int),
           typeof(PageControl),
           new FrameworkPropertyMetadata(0, OnPageSizePropertyChanged));

        public int PageSize
        {
            get => (int)GetValue(PageSizeProperty);
            set => SetValue(PageSizeProperty, value);
        }
        public static readonly DependencyProperty CountProperty =
           DependencyProperty.Register(
           "Count",
           typeof(long),
           typeof(PageControl),
           new FrameworkPropertyMetadata(0L, OnCountPropertyChanged));

        public long Count
        {
            get => (long)GetValue(CountProperty);
            set => SetValue(CountProperty, value);
        }
        public PageControl()
        {
            InitializeComponent();
            PrevButton.Click += PrevButton_Click;
            NextButton.Click += NextButton_Click;
        }
        private static void OnPageNumberPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SetPageInfo(d);
        }
        private static void OnPageSizePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SetPageInfo(d);
        }
        private static void OnCountPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SetPageInfo(d);
        }
        private static void SetPageInfo(DependencyObject d)
        {
            PageControl control = (PageControl)d;
            var totalPage = (int)Math.Ceiling((double)control.Count / control.PageSize);
            ((Label)control.FindName("CurrentText")).Content = $"当前{control.PageNumber}/{totalPage}页";
            ((Label)control.FindName("TotalText")).Content = $"共{control.Count}条";
            ((Button)control.FindName("PrevButton")).IsEnabled = 1 == control.PageNumber ? false:true;
            ((Button)control.FindName("NextButton")).IsEnabled = totalPage == control.PageNumber ? false: true;
        }
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
           NextCommand?.Execute(null);
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            PrevCommand?.Execute(null);
        }
    }
}
