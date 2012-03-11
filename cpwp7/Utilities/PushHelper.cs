using Microsoft.Phone.Notification;
using System;

namespace cpwp7.Utilities
{
    public class PushHelper
    {
        #region Public Events

        public delegate void UriUpdatedEventHandler(string uri);

        public delegate void ErrorEventHandler(NotificationChannelErrorEventArgs e);

        public event ErrorEventHandler Error;

        public delegate void RawNotificationReceivedEventHandler(string data);

        public event RawNotificationReceivedEventHandler RawNotificationReceived;

        #endregion

        #region Public Methods

        public void RegisterPushNotifications()
        {
            if (pushChannel != null) return;

            pushChannel = HttpNotificationChannel.Find(channelName);

            // If the channel was not found, then create a new connection to the push service.
            if (pushChannel == null)
            {
                pushChannel = new HttpNotificationChannel(channelName, "PositiveSSL CA");

                // Register for all the events before attempting to open the channel.
                pushChannel.ChannelUriUpdated += PushChannel_ChannelUriUpdated;
                pushChannel.ErrorOccurred += PushChannel_ErrorOccurred;
                pushChannel.HttpNotificationReceived += PushChannel_HttpNotificationReceived;

                pushChannel.Open();
                pushChannel.BindToShellToast();
                pushChannel.BindToShellTile();

                System.Diagnostics.Debug.WriteLine("Connetion: " + pushChannel.ConnectionStatus.ToString());
                System.Diagnostics.Debug.WriteLine("Bound: " + pushChannel.IsShellTileBound.ToString());
            }
            else
            {
                // The channel was already open, so just register for all the events.
                pushChannel.ChannelUriUpdated += PushChannel_ChannelUriUpdated;
                pushChannel.ErrorOccurred += PushChannel_ErrorOccurred;
                pushChannel.HttpNotificationReceived += PushChannel_HttpNotificationReceived;

                System.Diagnostics.Debug.WriteLine("Connetion2: " + pushChannel.ConnectionStatus.ToString());
                System.Diagnostics.Debug.WriteLine("Bound2: " + pushChannel.IsShellTileBound.ToString());
            }

            //if (UriUpdated != null && pushChannel.ChannelUri != null)
            //{
            //    UriUpdated(pushChannel.ChannelUri.ToString());
            //}
        }

        public void CloseChannel()
        {
            pushChannel.Close();
            pushChannel = null;
        }

        #endregion

        #region Public Properties

        public string PushChannelUri
        {
            get
            {
                if (pushChannel.ChannelUri == null)
                {
                    return null;
                }
                else
                {
                    return pushChannel.ChannelUri.ToString();
                }
            }
        }

        #endregion

        #region Private Fields

        /// Holds the push channel that is created or found.
        private static HttpNotificationChannel pushChannel;

        private const string channelName = "CouchBeardChannel";

        #endregion

        #region Private Methods

        private void PushChannel_ChannelUriUpdated(object sender, NotificationChannelUriEventArgs e)
        {
            App.Current.Couch.RegisterPushKey(e.ChannelUri);

            System.Diagnostics.Debug.WriteLine("Changed to:" + e.ChannelUri.ToString());
        }

        private void PushChannel_ErrorOccurred(object sender, NotificationChannelErrorEventArgs e)
        {
            // Error handling logic for your particular application would be here.
            if (Error != null)
            {
                Error(e);
            }
        }

        private void PushChannel_HttpNotificationReceived(object sender, HttpNotificationEventArgs e)
        {
            using (var reader = new System.IO.StreamReader(e.Notification.Body))
            {
                var data = reader.ReadToEnd();

                if (RawNotificationReceived != null)
                {
                    RawNotificationReceived(data);
                }
            }
        }

        #endregion
    }
}