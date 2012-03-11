using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using cpwp7.Model;
using System.Collections.Generic;
using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using cpwp7.Utilities;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;

namespace cpwp7.ViewModel
{
   
    public class ShowListViewModel : ViewModelBase
    {

        // To store the Movies service returned by the locator
        private readonly IShowService _showsService;

        private readonly INavigationService _navigationService;

        // To store the movies. It should be bind the the listbox in the view
        public ObservableCollection<ShowViewModel> Shows
        {
            get;
            private set;
        }

        public RelayCommand<ShowViewModel> ShowShowCommand
        {
            get;
            private set;
        }


        /// <summary>
        /// Initializes a new instance of the WantedMoviesViewModel class.
        /// </summary>
        public ShowListViewModel(IShowService showsService, INavigationService navigationService)
        {
            // The data service
            _showsService = showsService;

            // Get all the movies and add them to the Movies collection
            Shows = new ObservableCollection<ShowViewModel>();

            ShowShowCommand = new RelayCommand<ShowViewModel>(ShowShow);

            _showsService.GetShows((result, error) =>
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

                foreach (var show in result)
                {
                    var showViewModel = new ShowViewModel();
                    showViewModel.setShow(show);
                    Shows.Add(showViewModel);
                }

            });           

        }

        private void ShowShow(ShowViewModel show)
        {
            if (!SimpleIoc.Default.Contains<NewsItemViewModel>(item.Link.ToString()))
            {
                SimpleIoc.Default.Register(
                    () => new ShowViewModel
                    {
                        Model = show    
                    },
                    show.Model.Id);
            }

            _navigationService.NavigateTo(
                new Uri(
                    string.Format(ViewModelLocator.NewsItemUrl, item.Link),
                    UriKind.Relative));
        }
    }
}