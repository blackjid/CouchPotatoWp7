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
    public class ShowService : IShowService
    {
        public void GetShows(Action<IList<Show>, Exception> callback)
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
                var result = new List<Show>();

                // Parse the json response
                JObject o = JObject.Parse(e.Result);
                foreach (JToken jtShow in o["data"])
                {
                    var id = ((JProperty)jtShow).Name.ToString();
                    
                    // Create the movies
                    var show = new Show();
                    show.Id = id;
                    show.Name = ((string)jtShow.First["show_name"]).ToUpper();
                    //tvshow.Plot = (string)jtShow["library"]["plot"];
                    show.NextAir = ((string)jtShow.First["next_ep_airdate"]);
                    show.Art = App.Current.Sick.GetPoster(id);
                    
                        //movie.Backdrop = App.Current.Couch.FileCache((string)jtMovie["library"]["files"][2]["path"]);

                    result.Add(show);
                }

                GlobalLoading.Instance.IsLoading = false;

                callback(result, null);
            };

            // Make the call to the server
            client.DownloadStringAsync(App.Current.Sick.ShowList());
        }

        public void GetSeasons(string showId, Action<IList<Season>, Exception> callback)
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
                var result = new List<Season>();

                // Parse the json response
                JObject o = JObject.Parse(e.Result);
                foreach (int jtShow in o["data"])
                {
                    // Create the movies
                    var showSeason = new Season();
                    showSeason.Number = jtShow.ToString();
                    result.Add(showSeason);
                }

                callback(result, null);
            };

            // Make the call to the server
            client.DownloadStringAsync(App.Current.Sick.GetSeasonList(showId));
        }
    }
}
