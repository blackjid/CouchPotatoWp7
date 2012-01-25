using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using cpwp7.Model;
using System.Collections.Generic;
using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace cpwp7.ViewModel
{
   
    public class AddedShowsViewModel : ViewModelBase
    {

        // To store the Movies service returned by the locator
        private readonly IShowService _showsService;

        // To store the movies. It should be bind the the listbox in the view
        public ObservableCollection<ShowViewModel> Shows
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the WantedMoviesViewModel class.
        /// </summary>
        public AddedShowsViewModel(IShowService showsService)
        {
            // The data service
            _showsService = showsService;

            // Get all the movies and add them to the Movies collection
            Shows = new ObservableCollection<ShowViewModel>();
            _showsService.GetShows((result, error) =>
            {
                if (error != null)
                {
                    MessageBox.Show(error.Message);
                    return;
                }

                if (result == null)
                {
                    MessageBox.Show("Nothing found");
                    return;
                }

                List<Show> shows = (List<Show>)result;
                shows.Reverse();

                foreach (var show in shows)
                {
                    Shows.Add(new ShowViewModel(show));
                }

                // Change panorama background
                //BitmapImage bitmapImage = new BitmapImage();
                //bitmapImage.UriSource = new Uri(Movies[0].Model.Backdrop);
                //ImageBrush imageBrush = new ImageBrush();
                //imageBrush.Opacity = 0.5;
                //imageBrush.Stretch = Stretch.Uniform;
                //imageBrush.ImageSource = bitmapImage;

                //App.Current.UI.AppBackground = imageBrush;
            });

            

        }
    }
}