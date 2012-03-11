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
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using cpwp7.Model;

namespace cpwp7.Services
{
    public class MovieService : IMovieService
    {
        public void GetWanted(Action<IList<Movie>, Exception> callback) {
            // Create the client
            WebClient client = new WebClient();

            // Process the response from the server
            client.DownloadStringCompleted += (sender, e) =>
            {
                if (e.Error != null)
                {
                    callback(null, e.Error);
                    return;
                }

                // A list to store the movies
                var result = new List<Movie>();

                // Parse the json response
                JObject o = JObject.Parse(e.Result);
                foreach (JToken jtMovie in o["movies"])
                {
                    // Create the movies
                    var movie = new Movie();
                    movie.Name = ((string)jtMovie["library"]["titles"][0]["title"]).ToUpper();
                    movie.Plot = (string)jtMovie["library"]["plot"];
                    movie.Art = App.Current.Couch.FileCache((string)jtMovie["library"]["files"][0]["path"]);
                    movie.Year = jtMovie["library"]["year"].ToString();
                    //movie.Backdrop = App.Current.Couch.FileCache((string)jtMovie["library"]["files"][2]["path"]);

                    result.Add(movie);
                }

                callback(result, null);
            };

            // Make the call to the server
            client.DownloadStringAsync(App.Current.Couch.MovieList("active"));
        }
        
        public void GetMovies(Action<IList<Movie>, Exception> callback)
        {
            // Create the client
            WebClient client = new WebClient();

            // Process the response from the server
            client.DownloadStringCompleted += (sender, e) =>
            {
                if (e.Error != null)
                {
                    callback(null, e.Error);
                    return;
                }

                // A list to store the movies
                var result = new List<Movie>();

                // Parse the json response
                JObject o = JObject.Parse(e.Result);
                foreach (JToken jtMovie in o["movies"])
                {
                    // Create the movies
                    var movie = new Movie();
                    movie.Name = ((string)jtMovie["library"]["titles"][0]["title"]).ToUpper();
                    movie.Plot = (string)jtMovie["library"]["plot"];
                    movie.Art = App.Current.Couch.FileCache((string)jtMovie["library"]["files"][0]["path"]);
                    movie.Year = jtMovie["library"]["year"].ToString();
                    //movie.Backdrop = App.Current.Couch.FileCache((string)jtMovie["library"]["files"][2]["path"]);

                    result.Add(movie);
                }

                callback(result, null);
            };

            // Make the call to the server
            client.DownloadStringAsync(App.Current.Couch.MovieList("done"));
        }        
    }
}
