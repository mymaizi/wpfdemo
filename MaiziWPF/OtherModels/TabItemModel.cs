using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace MaiziWPF.OtherModels
{
    public class TabItemModel
    {
        public string Header { get; set; }
        public Frame Content { get; set; }
        public int TabIndex { get; set; }
    }
}
