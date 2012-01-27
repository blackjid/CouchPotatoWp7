using System;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using System.Windows;
using GalaSoft.MvvmLight;

namespace cpwp7.Model
{
    public class Episode : ObservableObject
    {

        // The plot of the movie.
        public string Airdate { get; set; }

        // The plot of the movie.
        public string Name { get; set; }

        // The plot of the movie.
        public string Quality { get; set; }

        // The plot of the movie.
        public string Status { get; set; }

        public Episode()
        {
        }
    }
}
