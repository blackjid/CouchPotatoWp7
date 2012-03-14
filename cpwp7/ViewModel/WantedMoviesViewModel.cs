using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using cpwp7.Model;
using System.Collections.Generic;
using System;
using System.Windows;
using cpwp7.Services;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace cpwp7.ViewModel
{
   
    public class WantedMoviesViewModel : ViewModelBase
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
        public WantedMoviesViewModel(IMovieService moviesService)
        {
            // The data service
            _moviesService = moviesService;

            // Get all the movies and add them to the Movies collection
            Movies = new ObservableCollection<MovieViewModel>();
            _moviesService.GetWanted((result, error) =>
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

                foreach (var movie in result)
                {
                    Movies.Add(new MovieViewModel(movie));
                }
            });
            //ShowMovieCommand = new RelayCommand<SelectionChangedEventArgs>(e => OnShowMovieCommand(e));
        }
        //public static ICommand ShowMovieCommand { get; private set; }
        //private void OnShowMovieCommand(SelectionChangedEventArgs e)
        //{
        //    NavigationService.NavigateTo(new Uri("/Pages/Movie.xaml", UriKind.Relative));
        //}
    }
}