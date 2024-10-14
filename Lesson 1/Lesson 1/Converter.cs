using Lesson_1.Properties;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Lesson_1
{
    internal class CountryGrouper : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"Country: {value}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    [ValueConversion(typeof(Decimal), typeof(String))]
    internal class CurrencyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((decimal)value).ToString(Settings.Default.Currency);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    [ValueConversion(typeof(DateTime), typeof(Brush))]
    internal class YearConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var day = ((DateTime)value).Day;

            if (day < 10) { return new SolidColorBrush(Colors.Purple); }
            if (day >= 10 && day < 20) { return new SolidColorBrush(Colors.Green); }
            if (day > 20) { return new SolidColorBrush(Colors.Red); }
            return new SolidColorBrush(Colors.Yellow);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
