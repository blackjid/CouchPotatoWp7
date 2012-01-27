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
using System.Collections;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using cpwp7.ViewModel;

namespace cpwp7.View
{
    public partial class ShowsView : UserControl
    {
        public ShowsView()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Avoid entering an infinite loop
            if (e.AddedItems.Count == 0)
            {
                return;
            }
            IList selectedItems = e.AddedItems;
            ShowViewModel show = selectedItems.OfType<ShowViewModel>().FirstOrDefault();

            //string val = selectedItems.OfType<string>().FirstOrDefault();
            (Application.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/Pages/ShowPage.xaml?" + show.Model.Id, UriKind.Relative));

            // Clear the listbox selection
            //((ListBox)sender).SelectedItem = null;
        }
    }
}
