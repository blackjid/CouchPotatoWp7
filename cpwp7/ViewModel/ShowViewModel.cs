using GalaSoft.MvvmLight;
using cpwp7.Model;
using System.Windows;

namespace cpwp7.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// </summary>
    public class ShowViewModel : ViewModelBase
    {
        public Show Model
        {
            get;
            private set;
        }
        
        /// <summary>
        /// Initializes a new instance of the ShowViewModel class.
        /// </summary>
        public ShowViewModel(Show model)
        {
            Model = model;
        }
    }
}