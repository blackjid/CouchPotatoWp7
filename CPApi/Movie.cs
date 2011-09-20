using System;
using System.ComponentModel;
using Newtonsoft.Json.Linq;
using System.Windows.Media.Imaging;
using System.Windows;

namespace CPApi
{
    public class Movie : DependencyObject
    {

        public Movie(JToken _movieToken)
        {
            this.Name = (string)_movieToken["library"]["titles"][0]["title"];
            this.Plot = (string)_movieToken["library"]["plot"];
            //this.Art = "http://beta.quehambre.cl:5000/98c106bf13734da7a630317f930e5d00/file.cache" + (string)_movieToken["library"]["files"][1]["path"];
        }
        // The name of the movie.
        public string Name { get; set; }

        // The plot of the movie.
        public string Plot { get; set; }

        // The plot of the movie.
        //public string Art { get; set; }

        //public BitmapImage Art
        //{
        //    get { return (BitmapImage)this.GetValue(ArtProperty); }
        //    set { this.SetValue(ArtProperty, value); }
        //}
        //public static DependencyProperty ArtProperty = DependencyProperty.Register("Art",
        //    typeof(BitmapImage), typeof(Movie),
        //    new PropertyMetadata(null));

        

    }
}
