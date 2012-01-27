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
   
    public class LatestMoviesViewModel : ViewModelBase
    {

        // To store the Movies service returned by the locator
        private readonly IMoviesService _moviesService;

        // To store the movies. It should be bind the the listbox in the view
        public ObservableCollection<MovieViewModel> Movies
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the WantedMoviesViewModel class.
        /// </summary>
        public LatestMoviesViewModel(IMoviesService moviesService)
        {
            // The data service
            _moviesService = moviesService;

            // Get all the movies and add them to the Movies collection
            Movies = new ObservableCollection<MovieViewModel>();
            _moviesService.GetMovies((result, error) =>
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

                List<Movie> movies = (List<Movie>)result;
                movies.Reverse();

                foreach (var movie in movies)
                {
                    Movies.Add(new MovieViewModel(movie));
                }

            });

            

        }
    }
}