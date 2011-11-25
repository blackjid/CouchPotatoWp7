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
                var movie = new Movie
                {
                    Name = ("Name" + index).ToUpper(),
                    Plot = "Plot" + index,
                    Art = couch.FileCache("/volume1/downloads/dev/CouchPotatoServer/_data/cache/0e0a26205d1012ba6692972c57eb7618.jpg/"),
                    Backdrop = couch.FileCache("/volume1/downloads/dev/CouchPotatoServer/_data/cache/761d3c67b737bba21fae2acc6040bde5.jpg")
                };

                result.Add(movie);
            }

            callback(result, null);
        }

        public DesignDataService()
        {
            // Initialize the CouchPotat API
            couch = new CouchApi();
            couch.ApiKey = "67540cc586b748f68dfdd63c05495cf0";
            couch.Host = "nas.blackjid.info";
            couch.Port = "5007";
        }

    }
}