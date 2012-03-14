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
using GalaSoft.MvvmLight.Messaging;

namespace cpwp7.ViewModel
{
   
    public class MovieDetailsViewModel : ViewModelBase
    {

        /// <summary>
        /// The <see cref="SelectedFriend" /> property's name.
        /// </summary>
        public const string SelectedMoviePropertyName = "SelectedMovie";

        private MovieViewModel _selectedMovie = null;

        /// <summary>
        /// Gets the SelectedFriend property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
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

                _selectedMovie = value;
                RaisePropertyChanged(SelectedMoviePropertyName);
            }
        }
                
        /// <summary>
        /// Initializes a new instance of the MovieDetailsViewModel class.
        /// </summary>
        public MovieDetailsViewModel(IMovieService moviesService)
        {
            Messenger.Default.Register<PropertyChangedMessage<MovieViewModel>>(
                this,
                message =>
                {
                    SelectedMovie = null;
                    SelectedMovie = message.NewValue;
                });
        }
    }
}