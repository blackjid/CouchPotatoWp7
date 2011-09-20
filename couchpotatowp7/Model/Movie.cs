using System;
using System.ComponentModel;
using Newtonsoft.Json.Linq;
using System.Windows.Media.Imaging;
using System.Windows;

namespace couchpotatowp7
{
    public class Movie
    {

        // The name of the movie.
        public string Name { get; set; }

        // The plot of the movie.
        public string Plot { get; set; }

        // The plot of the movie.
        public string Art { get; set; }

        public Movie() { 
        
        }

        public Movie(JToken _movieToken)
        {
            this.Name = (string)_movieToken["library"]["titles"][0]["title"];
            this.Plot = (string)_movieToken["library"]["plot"];
            this.Art = "http://beta.quehambre.cl:5000/98c106bf13734da7a630317f930e5d00/file.cache" + (string)_movieToken["library"]["files"][1]["path"];
        }
    }
}
