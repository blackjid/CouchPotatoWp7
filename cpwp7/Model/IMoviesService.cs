using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cpwp7.Model
{
    public interface IMoviesService
    {   
        /// <summary>
        /// Get all the movies in couch potato
        /// </summary>
        /// <param name="callback">Callback function with Movie List and error paramenter</param>
        void GetMovies(Action<IList<Movie>, Exception> callback);
    }
}
