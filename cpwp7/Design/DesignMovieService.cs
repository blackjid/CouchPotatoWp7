﻿using System;
using cpwp7.Model;
using cpwp7.Utilities;
using System.Collections.Generic;

namespace cpwp7.Design
{
    public class DesignMovieDataService : IMoviesService
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
                    Art = "http://nas.blackjid.info:5050/7c9fad341b764a5f8c4781c76f3cbc24/file.cache/97dc7c188a23e1af8c772670871b8918.jpg",
                    //Backdrop = couch.FileCache("/volume1/downloads/dev/CouchPotatoServer/_data/cache/761d3c67b737bba21fae2acc6040bde5.jpg")
                };

                result.Add(movie);
            }

            callback(result, null);
        }

        public DesignMovieDataService()
        {
            // Initialize the CouchPotat API
            couch = new CouchApi();
            couch.ApiKey = "7c9fad341b764a5f8c4781c76f3cbc24";
            couch.Host = "nas.blackjid.info";
            couch.Port = "5050";
        }

    }
}