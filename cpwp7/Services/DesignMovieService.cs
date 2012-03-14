using System;
using cpwp7.Model;
using cpwp7.Utilities;
using System.Collections.Generic;

namespace cpwp7.Services
{
    public class DesignMovieDataService : IMovieService
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
                    Plot = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting",
                    Art = "http://nas.blackjid.info:5050/7c9fad341b764a5f8c4781c76f3cbc24/file.cache/0e805a1c080eee97ae227f73cd5b02fc.jpg",
                    Year = 2011,
                    ImdbRating = 7.5,
                    ImdbRatingCount = 0,
                    RottenRating = 86,
                    RottenRatingCount = 0,
                    Backdrop = couch.FileCache("/root/.couchpotato/cache/e6317f1d41614f9c9567c3a5a01ce45d.jpg")
                };

                result.Add(movie);
            }

            callback(result, null);
        }

        public void GetWanted(Action<IList<Movie>, Exception> callback)
        {
            // Use this to create design time data
            var result = new List<Movie>();

            // Create 15 new movies
            for (var index = 0; index < 15; index++)
            {
                var movie = new Movie
                {
                    Name = ("Name Wanted " + index).ToUpper(),
                    Plot = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting",
                    Art = "http://nas.blackjid.info:5050/7c9fad341b764a5f8c4781c76f3cbc24/file.cache/0e805a1c080eee97ae227f73cd5b02fc.jpg",
                    Year = 2011,
                    ImdbRating = 7.5,
                    ImdbRatingCount = 0,
                    RottenRating = 86,
                    RottenRatingCount = 0,
                    Backdrop = couch.FileCache("/root/.couchpotato/cache/e6317f1d41614f9c9567c3a5a01ce45d.jpg")
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