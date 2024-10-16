using Lesson_2.Properties;
using System.Globalization;
using System.Windows.Controls;

namespace Lesson_2
{
    internal class StringValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return value.ToString() == string.Empty ? new(false, Resources.StringError) : new(true, null);
        }
    }
}
