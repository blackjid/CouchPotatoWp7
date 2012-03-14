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
using cpwp7.Utilities;

namespace cpwp7.Services
{
    public class MovieService : IMovieService
    {
        public void GetWanted(Action<IList<Movie>, Exception> callback) {
            GlobalLoading.Instance.IsLoading = true;
            
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
                    movie.Year = (int)jtMovie["library"]["year"];
                    if (jtMovie["library"]["info"]["rating"]["imdb"][0].ToString() != "N/A")
                        movie.ImdbRating = (float)jtMovie["library"]["info"]["rating"]["imdb"][0];
                    else
                        movie.ImdbRating = 0;
                    if (jtMovie["library"]["info"]["rating"]["imdb"][1].ToString() != "N/A")
                        movie.ImdbRatingCount = (int)jtMovie["library"]["info"]["rating"]["imdb"][1];
                    else
                        movie.ImdbRatingCount = 0;
                    movie.RottenRating = (int)jtMovie["library"]["info"]["rating"]["rotten"][0];
                    movie.RottenRatingCount = (int)jtMovie["library"]["info"]["rating"]["rotten"][1];
                    //movie.Backdrop = App.Current.Couch.FileCache((string)jtMovie["library"]["files"][2]["path"]);

                    result.Add(movie);
                }

                GlobalLoading.Instance.IsLoading = false;

                callback(result, null);
            };

            // Make the call to the server
            client.DownloadStringAsync(App.Current.Couch.MovieList("active"));
        }
        
        public void GetMovies(Action<IList<Movie>, Exception> callback)
        {
            GlobalLoading.Instance.IsLoading = true;

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
                    movie.Year = (int)jtMovie["library"]["year"];
                    if (jtMovie["library"]["info"]["rating"]["imdb"][0].ToString() != "N/A")
                        movie.ImdbRating = (double)jtMovie["library"]["info"]["rating"]["imdb"][0];
                    else
                        movie.ImdbRating = 0;
                    if (jtMovie["library"]["info"]["rating"]["imdb"][1].ToString() != "N/A")
                        movie.ImdbRatingCount = (int)jtMovie["library"]["info"]["rating"]["imdb"][1];
                    else
                        movie.ImdbRatingCount = 0;
                    movie.RottenRating = (int)jtMovie["library"]["info"]["rating"]["rotten"][0];
                    movie.RottenRatingCount = (int)jtMovie["library"]["info"]["rating"]["rotten"][1];
                    //movie.Backdrop = App.Current.Couch.FileCache((string)jtMovie["library"]["files"][2]["path"]);

                    result.Add(movie);
                }

                GlobalLoading.Instance.IsLoading = false;

                callback(result, null);
            };

            // Make the call to the server
            client.DownloadStringAsync(App.Current.Couch.MovieList("done"));
        }        
    }
}
