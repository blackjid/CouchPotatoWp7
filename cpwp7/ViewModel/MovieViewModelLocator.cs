using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using cpwp7.Model;

namespace cpwp7.ViewModel
{
    public class MovieViewModelLocator
    {
        static MovieViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IMoviesService, Design.DesignMovieDataService>();

            }
            else
            {
                SimpleIoc.Default.Register<IMoviesService, MoviesService>();
            }

            SimpleIoc.Default.Register<WantedMoviesViewModel>();

            SimpleIoc.Default.Register<LatestMoviesViewModel>();
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        public WantedMoviesViewModel WantedMovies
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WantedMoviesViewModel>();
            }
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        public LatestMoviesViewModel LatestMovies
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LatestMoviesViewModel>();
            }
        }

        
    }
}