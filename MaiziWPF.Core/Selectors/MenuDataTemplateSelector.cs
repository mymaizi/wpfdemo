using MaiziWPF.Services.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace MaiziWPF.Core
{
    public class MenuDataTemplateSelector: DataTemplateSelector
    {
        public DataTemplate MenuExpander { get; set; }
        public DataTemplate MenuButton { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item != null)
            {
                return item is SysMenu sysMenu && sysMenu.MenuType == "M" ? MenuExpander : MenuButton;
            }
            return base.SelectTemplate(item, container);
        }
    }
}
