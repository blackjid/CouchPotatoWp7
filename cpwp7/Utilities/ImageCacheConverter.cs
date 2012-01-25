using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.ComponentModel;

namespace cpwp7.Utilities
{
    public class ImageCacheConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (DesignerProperties.IsInDesignTool)
                return value;
            return ImageCache.GetImage(value.ToString());    
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
