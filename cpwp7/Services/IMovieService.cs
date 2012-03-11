using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cpwp7.Model;
using System.Net;

namespace cpwp7.Services
{
    public interface IMovieService
    {   
        /// <summary>
        /// Get all the movies in couch potato
        /// </summary>
        /// <param name="callback">Callback function with Movie List and error paramenter</param>
        void GetMovies(Action<IList<Movie>, Exception> callback);

        /// <summary>
        /// Get all the wanted movies in couch potato
        /// </summary>
        /// <param name="callback">Callback function with Movie List and error paramenter</param>
        void GetWanted(Action<IList<Movie>, Exception> callback);
    }
}
