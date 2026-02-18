using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaiziWPF.Core
{
    /// <summary>
    /// DateRangeControl.xaml 的交互逻辑
    /// </summary>
    public partial class DateRangeControl : UserControl
    {
        public static readonly DependencyProperty StartDateProperty = DependencyProperty.Register("StartDateTime", typeof(DateTime), typeof(DateRangeControl),new FrameworkPropertyMetadata(null));
        public DateTime StartDateTime { get => (DateTime)GetValue(StartDateProperty); set => SetValue(StartDateProperty, value); }
        public static readonly DependencyProperty EndDateProperty =  DependencyProperty.Register("EndDateTime", typeof(DateTime), typeof(DateRangeControl), new FrameworkPropertyMetadata(null));
        public DateTime EndDateTime { get => (DateTime)GetValue(EndDateProperty); set => SetValue(EndDateProperty, value); }
        public DateRangeControl()
        {
            InitializeComponent(); 
            this.CancelDateRange.Click += CancelDateRange_Click;
            this.ConfirmDateRange.Click += ConfirmDateRange_Click;
            this.StartDate.SelectedDatesChanged += StartDate_SelectedDatesChanged;
            this.EndDate.SelectedDatesChanged += EndDate_SelectedDatesChanged;
            this.EndDateText.TextChanged += EndDateText_TextChanged;
        }

        private void EndDateText_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == "")
            {
                this.StartDateText.Text = "";
            }
        }

        private void EndDate_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            Calendar calendar = sender as Calendar;
            if (calendar != null && calendar.SelectedDate.HasValue)
            {
                this.StartDate.BlackoutDates.Clear();
                this.StartDate.BlackoutDates.Add(new CalendarDateRange(calendar.SelectedDate.Value.AddDays(1), DateTime.MaxValue));
            }
        }

        private void StartDate_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            Calendar calendar = sender as Calendar;
            if (calendar != null && calendar.SelectedDate.HasValue)
            {
                this.EndDate.BlackoutDates.Clear();
                this.EndDate.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, calendar.SelectedDate.Value.AddDays(-1)));
            }
        }

        private void ConfirmDateRange_Click(object sender, RoutedEventArgs e)
        {
            if (this.StartDate.SelectedDate.HasValue && this.EndDate.SelectedDate.HasValue)
            {
                this.StartDateText.Text = this.StartDate.SelectedDate.Value.ToString("yyyy-MM-dd");
                this.EndDateText.Text = this.EndDate.SelectedDate.Value.ToString("yyyy-MM-dd");
                this.StartDateTime = this.StartDate.SelectedDate.Value;
                this.EndDateTime = this.EndDate.SelectedDate.Value;
                this.DateRangePopupBox.IsPopupOpen = false;
            }
        }

        private void CancelDateRange_Click(object sender, RoutedEventArgs e)
        {
            this.StartDate.SelectedDate = null;
            this.StartDate.DisplayDateStart = null;
            this.StartDate.DisplayDateEnd = null;
            this.EndDate.SelectedDate = null;
            this.EndDate.DisplayDateStart = null;
            this.EndDate.DisplayDateEnd = null;
            this.StartDate.BlackoutDates.Clear();
            this.EndDate.BlackoutDates.Clear();
            this.DateRangePopupBox.IsPopupOpen = false;
        }
    }
}
