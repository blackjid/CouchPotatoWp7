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
using System.Collections.Generic;

namespace cpwp7.Utilities
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
        const string FileCacheMethod = "file.cache";
        
        #region basic properties

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
        /// Get or set the Port to be used by all calls. Port is mandatory for all 
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

        #endregion

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

        /// <summary>
        /// Get the all the movies
        /// </summary>
        /// <returns>A Uri object with the url to the server</returns>
        public Uri MovieList(string _sStatus) 
        {
            return new Uri(BaseUrl() + MovieListMethod + "?status=" + _sStatus);
        }

        /// <summary>
        /// Get the cached file url
        /// </summary>
        /// <param name="_url">the file identifier</param>
        /// <returns></returns>
        public string FileCache(string _url)
        {
            return BaseUrl() + FileCacheMethod + _url;
        }

        /// <summary>
        /// Register the push notification uri in couchpotato settings
        /// </summary>
        /// <param name="_uri">Push Channel uri</param>
        public void RegisterPushKey(Uri _uri)
        {
            // Create the client
            WebClient client = new WebClient();

            // Process the response from the server
            client.DownloadStringCompleted += (senderd, d) =>
            {
                if (d.Error != null)
                {
                    return;
                }

            };

            // Make the call to the server
            client.DownloadStringAsync(new Uri(App.Current.Couch.BaseUrl() + "notifier.wp7client.register/?key=" + _uri.ToString()));
        }
    }
}
