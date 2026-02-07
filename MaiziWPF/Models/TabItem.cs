using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace MaiziWPF
{
    public class TabItem
    {
        public string Header { get; set; }
        public object Content { get; set; }
        public int TabIndex { get; set; }
    }
}
