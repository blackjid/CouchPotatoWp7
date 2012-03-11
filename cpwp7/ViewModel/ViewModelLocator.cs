using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using cpwp7.Model;
using cpwp7.Services;

namespace cpwp7.ViewModel
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IMovieService, DesignMovieDataService>();
                SimpleIoc.Default.Register<IShowService, DesignShowDataService>();

            }
            else
            {
                SimpleIoc.Default.Register<IMovieService, MovieService>();
                SimpleIoc.Default.Register<IShowService, ShowService>();
            }

            SimpleIoc.Default.Register<ShowsViewModel>();
            SimpleIoc.Default.Register<SeasonViewModel>();

            SimpleIoc.Default.Register<WantedMoviesViewModel>();
            SimpleIoc.Default.Register<MoviesViewModel>();
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        public ShowsViewModel Shows
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ShowsViewModel>();
            }
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        public SeasonViewModel Seasons
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SeasonViewModel>();
            }
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
        public MoviesViewModel Movies
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MoviesViewModel>();
            }
        }
    }
}