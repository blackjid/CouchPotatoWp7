using System;
using System.Windows;
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;
using System.Net;
using Newtonsoft.Json.Linq;
using System.ComponentModel;

namespace couchpotatowp7.ViewModel
{
    public class MovieViewModel : INotifyPropertyChanged
    {

        public const string WantedMoviesPropertyName = "WantedMovies";

        private ObservableCollection<Movie> _wantedMovies;

        public ObservableCollection<Movie> WantedMovies
        {
            get
            {
                return _wantedMovies;
            }
            set
            {
                if (_wantedMovies == value)
                {
                    return;
                }

                _wantedMovies = value;
                RaisePropertyChanged(WantedMoviesPropertyName);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            { 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public MovieViewModel()
        {

            if (DesignerProperties.IsInDesignTool)
            {
                WantedMovies = new ObservableCollection<Movie>();

                for (var index = 0; index < 15; index++)
                {
                    var curstomer = new Movie
                    {
                        Name = "Name" + index,
                        Plot = "Plot" + index,
                        Art = (App.Current as App).Couch.BaseUrl() + "/file.cache/vxdata/CouchPotatoServer/_data/cache/3097ed097ed2430a20f52993eb399672.jpg"
                    };

                    WantedMovies.Add(curstomer);
                }
            }
            else
            {
                // Create the client
                WebClient myMovies = new WebClient();

                // Add an event handler
                myMovies.DownloadStringCompleted += new DownloadStringCompletedEventHandler(movieListDownloadCompleted);
                myMovies.DownloadStringAsync((App.Current as App).Couch.MovieList());
            }
        }

        void movieListDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                ObservableCollection<Movie> a = new ObservableCollection<Movie>();
                                
                JObject o = JObject.Parse(e.Result);
                foreach (JToken movie in o["movies"])
                {
                    a.Add(new Movie(movie));
                }

                WantedMovies = a;
            }
            catch (System.Exception excep)
            {
            
            }
        }
    }
}