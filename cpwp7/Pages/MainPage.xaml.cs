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

        private void AppBarNewMovie_Click(object sender, EventArgs e)
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
        

        private void Panorama_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            switch (((Panorama)sender).SelectedIndex)
            {
                case 0:
                    ApplicationBar = ((ApplicationBar)this.Resources["latestAppBar"]);
                    break;

                case 1:
                    ApplicationBar = ((ApplicationBar)this.Resources["wantedAppBar"]);
                    break;

                case 2:
                    ApplicationBar = ((ApplicationBar)this.Resources["moviesAppBar"]);
                    break;
            }
        }
        
        public void changeBackground(Uri _backUri)
        {
            BitmapImage bitmapImage = new BitmapImage(_backUri);
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = bitmapImage;

            MainPanorama.Background = imageBrush;
        }
    }
}
