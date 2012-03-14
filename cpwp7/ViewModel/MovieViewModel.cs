using GalaSoft.MvvmLight;
using cpwp7.Model;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace cpwp7.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// </summary>
    public class MovieViewModel : ViewModelBase
    {
        public Movie Model
        {
            get;
            private set;
        }
        
        /// <summary>
        /// Initializes a new instance of the MovieViewModel class.
        /// </summary>
        public MovieViewModel(Movie model)
        {
            Model = model;
        }

        //private void OnShowMovieCommand(SelectionChangedEventArgs e)
        //{
        //    var a = 1 + 1;
        //}
    }
}