using System;
using cpwp7.Model;
using cpwp7.Utilities;
using System.Collections.Generic;

namespace cpwp7.Services
{
    public class DesignShowDataService : IShowService
    {
        // To store the Couch Api to be used in the Design Data Service
        private CouchApi couch;
        
        public DesignShowDataService()
        {
            // Initialize the CouchPotat API
            couch = new CouchApi();
            couch.ApiKey = "f5d6701f555447546b6030432d15e229";
            couch.Host = "nas.blackjid.info";
            couch.Port = "8081";
        }

        public void GetShows(Action<IList<Show>, Exception> callback)
        {
            // Use this to create design time data
            var result = new List<Show>();

            // Create 15 new movies
            for (var index = 0; index < 15; index++)
            {
                var show = new Show
                {
                    Name = ("Name" + index).ToUpper(),
                    //Plot = "Plot" + index,
                    NextAir = "2012-02-13",
                    Art = "http://nas.blackjid.info:8081/api/f5d6701f555447546b6030432d15e229/show.getposter/75760"
                    //Backdrop = couch.FileCache("/volume1/downloads/dev/CouchPotatoServer/_data/cache/761d3c67b737bba21fae2acc6040bde5.jpg")
                };

                result.Add(show);
            }

            callback(result, null);
        }

        public void GetSeasons(string seasonId, Action<IList<Season>, Exception> callback)
        {
            // Use this to create design time data
            var result = new List<Season>();

            // Create 15 new movies
            for (var index = 0; index < 15; index++)
            {
                var season = new Season
                {
                    Number = (index + 1).ToString()
                    //Name = ("Name" + index).ToUpper(),
                    //Plot = "Plot" + index,
                    //NextAir = "2012-02-13",
                    //Art = "http://nas.blackjid.info:8081/api/f5d6701f555447546b6030432d15e229/show.getposter/75760"
                    //Backdrop = couch.FileCache("/volume1/downloads/dev/CouchPotatoServer/_data/cache/761d3c67b737bba21fae2acc6040bde5.jpg")
                };

                result.Add(season);
            }

            callback(result, null);
        }

    }
}