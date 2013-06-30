using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace cpwp7.View
{
    public partial class WantedMoviesView : UserControl
    {
        public WantedMoviesView()
        {
            InitializeComponent();
        }

        private void NewsItemTap(object sender, GestureEventArgs e)
        {
            var element = e.OriginalSource as FrameworkElement;
            
        }
    }
}
