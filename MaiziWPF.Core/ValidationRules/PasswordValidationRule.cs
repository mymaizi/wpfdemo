using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace MaiziWPF.Core
{
    public class PasswordValidationRule : ValidationRule
    {
        public static bool ShowValidationErrors { get; set; } = false;
        
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!ShowValidationErrors)
                return ValidationResult.ValidResult;
                
            var password = value?.ToString() ?? string.Empty;
            
            if (string.IsNullOrWhiteSpace(password))
            {
                return new ValidationResult(false, "密码不能为空");
            }
            
            if (password.Length < 6)
            {
                return new ValidationResult(false, "密码长度至少6位");
            }
            
            // 检查是否包含数字、字母和特殊字符
            var hasNumber = Regex.IsMatch(password, @"\d");
            var hasLetter = Regex.IsMatch(password, @"[a-zA-Z]");
            var hasSpecialChar = Regex.IsMatch(password, @"[^a-zA-Z\d]");
            
            if (!hasNumber || !hasLetter || !hasSpecialChar)
            {
                return new ValidationResult(false, "密码必须包含数字、字母和特殊字符");
            }
            
            return ValidationResult.ValidResult;
        }
    }
}