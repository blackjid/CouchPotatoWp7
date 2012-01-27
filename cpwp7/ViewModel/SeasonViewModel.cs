using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using cpwp7.Model;
using System.Collections.Generic;
using System;
using System.Windows;

namespace cpwp7.ViewModel
{
   
    public class SeasonViewModel : ViewModelBase
    {

        // To store the Movies service returned by the locator
        private readonly IShowService _showService;

        // To store the movies. It should be bind the the listbox in the view
        public ObservableCollection<Season> Seasons
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the WantedMoviesViewModel class.
        /// </summary>
        public SeasonViewModel(IShowService showService)
        {
            // The data service
            _showService = showService;

            // Get all the movies and add them to the Movies collection
            Seasons = new ObservableCollection<Season>();
            _showService.GetSeasons("75760", (result, error) =>
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

                foreach (var season in result)
                {
                    Seasons.Add(season);
                }
            });
        }
    }
}