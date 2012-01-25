using System;
using System.ComponentModel;
//using Newtonsoft.Json.Linq;
using System.Windows.Media.Imaging;
using System.Windows;
using GalaSoft.MvvmLight;

namespace cpwp7.Model
{
    public class Show : ObservableObject
    {

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

        public Show()
        {
        }

        /// <summary>
        /// The <see cref="Name" /> property's name.
        /// </summary>
        //public const string NamePropertyName = "Name";

        //private string _name;

        ///// <summary>
        ///// Sets and gets the Name property.
        ///// Changes to that property's value raise the PropertyChanged event. 
        ///// </summary>
        //public string Name
        //{
        //    get
        //    {
        //        return _name;
        //    }

        //    set
        //    {
        //        if (_name == value)
        //        {
        //            return;
        //        }

        //        _name = value;
        //        RaisePropertyChanged(NamePropertyName);
        //    }
        //}

        //public Movie(JToken _movieToken)
        //{
        //    this.Name = (string)_movieToken["library"]["titles"][0]["title"];
        //    this.Plot = (string)_movieToken["library"]["plot"];
        //    this.Art = "http://beta.quehambre.cl:5000/98c106bf13734da7a630317f930e5d00/file.cache" + (string)_movieToken["library"]["files"][1]["path"];
        //}
    }
}
