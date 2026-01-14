using System;
using System.Collections.Generic;
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

namespace WpfApp1
{
    /// <summary>
    /// TabPage2.xaml 的交互逻辑
    /// </summary>
    public partial class TabPage2 : Page
    {
        private Dictionary<string,string> queryDict=new();

        public TabPage2()
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
                var query = NavigationService?.CurrentSource + "";
                query = query.Substring(query.IndexOf('?') + 1) ?? "";
                query.Split('&').ToList().ForEach(q =>
                {
                    var kv = q.Split('=');
                    if (kv.Length == 2)
                    {
                        queryDict[kv[0]] = Uri.UnescapeDataString(kv[1]);
                    }
                });
                DataContext =$"This is {queryDict["data"]}" ;
            };
        }
    }
}
