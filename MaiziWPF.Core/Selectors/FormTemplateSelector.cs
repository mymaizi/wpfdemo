using System.Windows;
using System.Windows.Controls;

namespace MaiziWPF.Core
{
    public class FormTemplateSelector : DataTemplateSelector
    {
        public DataTemplate NewModeTemplate { get; set; }
        public DataTemplate EditModeTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item != null && item.GetType().GetProperty("IsEditMode") != null)
            {
                bool isEditMode = (bool)item.GetType().GetProperty("IsEditMode").GetValue(item);
                return isEditMode ? EditModeTemplate : NewModeTemplate;
            }
            return NewModeTemplate;
        }
    }
}