using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cpwp7.Model
{
    public interface IShowService
    {   
        /// <summary>
        /// Get all the tv shows in sick beard
        /// </summary>
        /// <param name="callback">Callback function with TV Shows List and error paramenter</param>
        void GetShows(Action<IList<Show>, Exception> callback);
    }
}
