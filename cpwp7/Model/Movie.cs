using System;
using System.ComponentModel;
//using Newtonsoft.Json.Linq;
using System.Windows.Media.Imaging;
using System.Windows;
using GalaSoft.MvvmLight;

namespace cpwp7.Model
{
    public class Movie : ObservableObject
    {

        // The plot of the movie.
        public string Name { get; set; }

        // The plot of the movie.
        public string Plot { get; set; }

        // The plot of the movie.
        public string Art { get; set; }

        // The plot of the movie.
        public string Backdrop { get; set; }

        // The year of the movie.
        public int Year { get; set; }

        // The year of the movie.
        public double ImdbRating { get; set; }

        // The year of the movie.
        public int ImdbRatingCount { get; set; }

        // The year of the movie.
        public int RottenRating { get; set; }

        // The year of the movie.
        public int RottenRatingCount { get; set; }

        public Movie() {

        }
    }
}
