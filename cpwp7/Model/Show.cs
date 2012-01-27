using System;
using System.ComponentModel;
//using Newtonsoft.Json.Linq;
using System.Windows.Media.Imaging;
using System.Windows;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace cpwp7.Model
{
    public class Show : ObservableObject
    {

        // The ID of the tv show.
        public string Id { get; set; }
        
        // The plot of the tv show.
        public string Name { get; set; }

        // The status of the tv show.
        public string Status { get; set; }

        // The network of the tv show.
        public string Network { get; set; }

        // The next air date of the tv show.
        public string NextAir { get; set; }

        // The next air date of the tv show.
        public string Art { get; set; }

        // The next air date of the tv show.
        public ObservableCollection<Season> Seasons { get; set; }

        public Show()
        {
        }
    }
}
