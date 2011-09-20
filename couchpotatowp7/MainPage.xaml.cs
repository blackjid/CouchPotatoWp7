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
using Microsoft.Phone.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using couchpotatowp7.ViewModel;
using Microsoft.Phone.Shell;

namespace couchpotatowp7
{
    public partial class MainPage : PhoneApplicationPage
    {

        private MovieViewModel vm;

        private AppSettings settings;
                
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            settings = new AppSettings();
            
            //vm = new MovieViewModel();

        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (settings.ApiKeySetting == "" || settings.HostSetting == "") {
                NavigationService.Navigate(new Uri("/SettingsPage.xaml", UriKind.Relative));
                return;
            }

            //vm.GetMovies();
            //wantendList.DataContext = vm.WantedMovies;
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

        }
        
        private void AppBarNewMovie_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddMovie.xaml", UriKind.Relative));
        }
        private void AppBarSettings_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/SettingsPage.xaml", UriKind.Relative));
        }

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((Pivot)sender).SelectedIndex)
            {
                case 0:
                    ApplicationBar = ((ApplicationBar)this.Resources["wantedAppBar"]);
                    break;

                case 1:
                    ApplicationBar = ((ApplicationBar)this.Resources["snatchedAppBar"]);
                    break;

                case 2:
                    ApplicationBar = ((ApplicationBar)this.Resources["downloadedAppBar"]);
                    break;
            }
        }

        
    }
}