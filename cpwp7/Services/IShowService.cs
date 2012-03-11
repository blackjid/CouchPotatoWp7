using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cpwp7.Model;

namespace cpwp7.Services
{
    public interface IShowService
    {   
        /// <summary>
        /// Get all the tv shows in sick beard
        /// </summary>
        /// <param name="callback">Callback function with TV Shows List and error paramenter</param>
        void GetShows(Action<IList<Show>, Exception> callback);

        /// <summary>
        /// Get all the tv shows in sick beard
        /// </summary>
        /// <param name="callback">Callback function with TV Shows List and error paramenter</param>
        void GetSeasons(string showId, Action<IList<Season>, Exception> callback);
    }
}
