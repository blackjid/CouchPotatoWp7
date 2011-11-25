using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace cpwp7.Utilities
{
    public class ImageCacheConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ImageCache.GetImage(value.ToString());    
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
