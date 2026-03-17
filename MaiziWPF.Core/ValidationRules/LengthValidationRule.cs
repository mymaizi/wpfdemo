using System.Globalization;
using System.Windows.Controls;

namespace MaiziWPF.Core
{
    public class LengthValidationRule : ValidationRule
    {
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public static bool ShowValidationErrors { get; set; } = false;
        
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!ShowValidationErrors)
                return ValidationResult.ValidResult;
                
            var str = value?.ToString() ?? string.Empty;
            
            if (str.Length < MinLength)
            {
                return new ValidationResult(false, $"长度不能少于{MinLength}个字符");
            }
            
            if (str.Length > MaxLength)
            {
                return new ValidationResult(false, $"长度不能超过{MaxLength}个字符");
            }
            
            return ValidationResult.ValidResult;
        }
    }
}