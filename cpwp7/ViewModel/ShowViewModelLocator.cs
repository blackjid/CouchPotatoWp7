using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using cpwp7.Model;

namespace cpwp7.ViewModel
{
    public class ShowViewModelLocator
    {
        static ShowViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IShowService, Design.DesignShowDataService>();

            }
            else
            {
                SimpleIoc.Default.Register<IShowService, ShowService>();
            }

            SimpleIoc.Default.Register<AddedShowsViewModel>();

            SimpleIoc.Default.Register<SeasonViewModel>();
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        public AddedShowsViewModel AddedShows
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddedShowsViewModel>();
            }
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        public SeasonViewModel ShowSeasons
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SeasonViewModel>();
            }
        } 
    }
}