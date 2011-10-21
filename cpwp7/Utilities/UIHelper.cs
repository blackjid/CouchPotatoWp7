using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace cpwp7.Utilities
{
    public class UIHelper : DependencyObject
    {
        /// <summary>
        /// The <see cref="AppBackground" /> dependency property's name.
        /// </summary>
        public const string AppBackgroundPropertyName = "AppBackground";

        /// <summary>
        /// Gets or sets the value of the <see cref="AppBackground" />
        /// property. This is a dependency property.
        /// </summary>
        public ImageBrush AppBackground
        {
            get
            {
                return (ImageBrush)GetValue(AppBackgroundProperty);
            }
            set
            {
                SetValue(AppBackgroundProperty, value);
            }
        }

        /// <summary>
        /// Identifies the <see cref="AppBackground" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty AppBackgroundProperty = DependencyProperty.Register(
            AppBackgroundPropertyName,
            typeof(ImageBrush),
            typeof(UIHelper),
            null);

        public UIHelper() { }
    }
}
