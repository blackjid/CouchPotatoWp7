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

namespace couchpotatowp7
{
    public class CouchApi
    {
        // The settings
        private string sHost;
        private string sApiKey;
        private string sPort;
        private string sUsername;
        private string sPassword;

        // Base for every call to the api
        private string sBaseUrl;

        // The api methods
        const string MovieListMethod = "movie.list";

        /// <summary>
        /// Get or set the API Key to be used by all calls. API key is mandatory for all 
        /// calls to Couch.
        /// </summary>
        public string ApiKey
        {
            get { return sApiKey; }
            set
            {
                sApiKey = value == null || value.Length == 0 ? null : value;
            }
        }

        /// <summary>
        /// Get or set the HOST to be used by all calls. HOST is mandatory for all 
        /// calls to Couch.
        /// </summary>
        public string Host
        {
            get { return sHost; }
            set
            {
                sHost = value == null || value.Length == 0 ? null : value;
            }
        }

        /// <summary>
        /// Get or set the HOST to be used by all calls. HOST is mandatory for all 
        /// calls to Couch.
        /// </summary>
        public string Port
        {
            get { return sPort; }
            set
            {
                sPort = value == null || value.Length == 0 ? null : value;
            }
        }

        /// <summary>
        /// Get the base url for all calls
        /// </summary>
        /// <returns></returns>
        public string BaseUrl()
        {
            if (sHost == null || sHost.Length == 0
                || sPort == null || sPort.Length == 0
                || sApiKey == null || sApiKey.Length == 0)
                sBaseUrl = null;
            else
                sBaseUrl = "http://" + sHost + ":" + sPort + "/" + sApiKey + "/";

                return sBaseUrl; 
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public CouchApi()
        { 
        
        }

        public Uri MovieList() 
        {
            return new Uri(BaseUrl() + MovieListMethod);
        }


    }
}
