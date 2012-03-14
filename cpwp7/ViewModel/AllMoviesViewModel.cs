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
   
    public class AllMoviesViewModel : ViewModelBase
    {
        // Only used in WP7
        public INavigationService NavigationService
        {
            get;
            set;
        }        

        // To store the Movies service returned by the locator
        private readonly IMovieService _moviesService;

        // To store the movies. It should be bind the the listbox in the view
        public ObservableCollection<MovieViewModel> Movies
        {
            get;
            private set;
        }

        /// <summary>
        /// The <see cref="SelectedFriend" /> property's name.
        /// </summary>
        public const string SelectedMoviePropertyName = "SelectedMovie";

        private MovieViewModel _selectedMovie = null;

        public MovieViewModel SelectedMovie
        {
            get
            {
                return _selectedMovie;
            }

            set
            {
                if (_selectedMovie == value)
                {
                    return;
                }

                var oldValue = _selectedMovie;
                _selectedMovie = value;

                //RaisePropertyChanged(SelectedMoviePropertyName);
                RaisePropertyChanged(SelectedMoviePropertyName, oldValue, _selectedMovie, true);
                if (NavigationService != null)
                {
                    NavigationService.NavigateTo(new Uri("/Pages/Movie.xaml", UriKind.Relative));
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the WantedMoviesViewModel class.
        /// </summary>
        public AllMoviesViewModel(IMovieService moviesService)
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