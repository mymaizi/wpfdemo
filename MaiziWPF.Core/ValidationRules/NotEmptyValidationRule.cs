using System.Globalization;
using System.Windows.Controls;

namespace MaiziWPF.Core
{
    public class NotEmptyValidationRule : ValidationRule
    {
        public static bool ShowValidationErrors { get; set; } = false;
        
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!ShowValidationErrors)
                return ValidationResult.ValidResult;
                
            return string.IsNullOrWhiteSpace(value?.ToString())
                ? new ValidationResult(false, "此字段不能为空")
                : ValidationResult.ValidResult;
        }
    }
}