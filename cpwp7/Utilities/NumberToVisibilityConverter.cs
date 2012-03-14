using System;
using System.Globalization;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;

namespace cpwp7.Utilities
{
    public class NumberToVisibilityConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (System.Convert.ToInt32(value) > 0) ? Visibility.Visible : Visibility.Collapsed;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
