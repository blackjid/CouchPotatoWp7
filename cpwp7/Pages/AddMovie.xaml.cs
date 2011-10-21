using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Newtonsoft.Json.Linq;

namespace couchpotatowp7
{
    public partial class AddMovie : PhoneApplicationPage
    {
        public AddMovie()
        {
            //InitializeComponent();
           // Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            //searchMovie.IsTextCompletionEnabled = false;

            // Server does the filtering
            //searchMovie.FilterMode = AutoCompleteFilterMode.None;

            //searchMovie.Populating += (s, args) =>
            //{
            //    args.Cancel = true;
            //    WebClient wc = new WebClient();
            //    string prefix = HttpUtility.UrlEncode(args.Parameter);
            //    Uri service = new Uri("http://beta.quehambre.cl:5000/5bb8d2249cad41a9a10106c344f3c47f/movie.search/?q=" + searchMovie.Text);
            //    wc.DownloadStringCompleted += DownloadStringCompleted;
            //    wc.DownloadStringAsync(service, s);
            //};
        }

        private void DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            //AutoCompleteBox acb = e.UserState as AutoCompleteBox;
            //if (acb != null && e.Error == null && !e.Cancelled && !string.IsNullOrEmpty(e.Result))
            //{
            //    List<string> suggestions = new List<string>();

            //    JObject o = JObject.Parse(e.Result);

            //    foreach (JToken movie in o["movies"])
            //    {
            //        suggestions.Add((string)movie["titles"][0]);
            //    }

            //    if (suggestions.Count > 0)
            //    {
            //        acb.ItemsSource = suggestions;
            //        acb.PopulateComplete();
            //    }

                
            //}
        }        
    }
}