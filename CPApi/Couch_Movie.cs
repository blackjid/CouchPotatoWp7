using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;

namespace CPApi
{
    public partial class Couch
    {
        // Collection of movies
        public ObservableCollection<Movie> Movies { get; set; }
        
        // The api methods
        const string MovieListMethod = "movie.list";
        
        /// <summary>
        /// Get all the movie list and set them in a observable collection
        /// </summary>
        /// <returns>Collection of Movie objects</returns>
        public void MovieList()
        {
            ObservableCollection<Movie> a = new ObservableCollection<Movie>();
            Movies = a;
            
            // Create the client
            WebClient myMovies = new WebClient();

            // Add an event handler
            myMovies.DownloadStringCompleted += new DownloadStringCompletedEventHandler(movieListDownloadCompleted);
            myMovies.DownloadStringAsync(new Uri(BaseUrl + MovieListMethod));
        }


        void movieListDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                JObject o = JObject.Parse(e.Result);
                foreach (JToken movie in o["movies"])
                {
                    Movies.Add(new Movie(movie));
                }
            }
            catch (System.Exception excep)
            {

            }
        }
    }
}
