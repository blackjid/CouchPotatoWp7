using System;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using System.Windows;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace cpwp7.Model
{
    public class Season : ObservableObject
    {

        // The season number
        public string Number { get; set; }

        // The plot of the movie.
        public ObservableCollection<Episode> Episodes { get; set; }
        
        public Season() {
        }
    }
}
