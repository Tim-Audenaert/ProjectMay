using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjectMay
{
    //SOURCE: https://stackoverflow.com/questions/33256045/wpf-validation-depending-on-required-not-required-field/33385575
    class RequiredFiedValidationRule : ValidationRule
    {
        public bool IsRequired { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var content = value.ToString();
            if (content != null)
            {
                if (IsRequired && string.IsNullOrWhiteSpace(content))
                    return new ValidationResult(false, "Required content");
            }
            return ValidationResult.ValidResult;
        }
    }
}
