using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using Microsoft.Phone.Notification;
using System.Net;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace cpwp7
{
    public partial class MainPage : PhoneApplicationPage
    {
        /// <summary>
        /// Push Uri for this application
        /// </summary>
        Uri uri;
        
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Background
            this.DataContext = App.Current.UI;
        }

        private void AppBarAddMovie_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/AddMovie.xaml", UriKind.Relative));
        }
        private void AppBarAllMovies_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/AllMovies.xaml", UriKind.Relative));
        }
        private void AppBarAddShow_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/AddMovie.xaml", UriKind.Relative));
        }
        private void AppBarSettings_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/SettingsPage.xaml", UriKind.Relative));
        }
        private void AppBarClearMovies_Click(object sender, EventArgs e)
        {
            // Clear downloaded movies
        }
        

        private void Pivot_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            switch (((Pivot)sender).SelectedIndex)
            {
                case 0:
                    ApplicationBar = ((ApplicationBar)this.Resources["moviesAppBar"]);
                    break;

                case 1:
                    ApplicationBar = ((ApplicationBar)this.Resources["showsAppBar"]);
                    break;

            }
        }
    }
}
