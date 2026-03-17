using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MaiziWPF.Core
{
    /// <summary>
    /// 编辑模式可见性转换器
    /// 用于根据编辑模式控制字段的显示/隐藏
    /// </summary>
    public class EditModeVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// 转换方法
        /// </summary>
        /// <param name="value">IsEditMode 布尔值</param>
        /// <param name="targetType">目标类型</param>
        /// <param name="parameter">参数："True"表示编辑模式下显示，"False"表示编辑模式下隐藏</param>
        /// <param name="culture">区域信息</param>
        /// <returns>可见性状态</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isEditMode && parameter is string param)
            {
                bool showInEditMode = param.Equals("True", StringComparison.OrdinalIgnoreCase);
                
                // 如果参数是 "True"，表示编辑模式下显示，新增模式下隐藏
                // 如果参数是 "False"，表示编辑模式下隐藏，新增模式下显示
                if (showInEditMode)
                {
                    return isEditMode ? Visibility.Visible : Visibility.Collapsed;
                }
                else
                {
                    return isEditMode ? Visibility.Collapsed : Visibility.Visible;
                }
            }
            
            // 默认情况下显示
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}