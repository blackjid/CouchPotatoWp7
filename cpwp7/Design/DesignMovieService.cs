using System;
using cpwp7.Model;
using cpwp7.Utilities;
using System.Collections.Generic;

namespace cpwp7.Design
{
    public class DesignDataService : IMoviesService
    {
        // To store the Couch Api to be used in the Design Data Service
        private CouchApi couch;
        
        public void GetMovies(Action<IList<Movie>, Exception> callback)
        {
            // Use this to create design time data
            var result = new List<Movie>();

            // Create 15 new movies
            for (var index = 0; index < 15; index++)
            {
                var curstomer = new Movie
                {
                    Name = "Name" + index,
                    Plot = "Plot" + index,
                    Art = couch.FileCache("/volume1/downloads/dev/CouchPotatoServer/_data/cache/3097ed097ed2430a20f52993eb399672.jpg/")
                };

                result.Add(curstomer);
            }

            callback(result, null);
        }

        public DesignDataService()
        {
            // Initialize the CouchPotat API
            couch = new CouchApi();
            couch.ApiKey = "98c106bf13734da7a630317f930e5d00";
            couch.Host = "nas.blackjid.info";
            couch.Port = "5007";
        }

    }
}