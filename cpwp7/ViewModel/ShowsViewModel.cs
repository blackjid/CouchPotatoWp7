using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using cpwp7.Model;
using System.Collections.Generic;
using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using cpwp7.Services;

namespace cpwp7.ViewModel
{
   
    public class ShowsViewModel : ViewModelBase
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
        public ShowsViewModel(IShowService showsService)
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

                foreach (var show in result)
                {
                    Shows.Add(new ShowViewModel(show));
                }

            });

            

        }
    }
}