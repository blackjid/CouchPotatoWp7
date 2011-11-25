using System;
using System.Windows;
using System.IO.IsolatedStorage;

namespace cpwp7.Utilities
{
    public class AppSettings
    {
        // Our isolated storage settings
        IsolatedStorageSettings settings;

        // The isolated storage key names of our settings
        const string ApiKeyKeyName = "ApiKeySetting";
        const string HostKeyName = "HostSetting";
        const string PortKeyName = "PortSetting";

        // The default value of our settings
        const string ApiKeySettingDefault = "67540cc586b748f68dfdd63c05495cf0";
        const string HostSettingDefault = "nas.blackjid.info";
        const string PortSettingDefault = "5007";

        /// <summary>
        /// Constructor that gets the application settings.
        /// </summary>
        public AppSettings()
        {
            // Get the settings for this application.
            settings = IsolatedStorageSettings.ApplicationSettings;
        }

        /// <summary>
        /// Update a setting value for our application. If the setting does not
        /// exist, then add the setting.
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool AddOrUpdateValue(string Key, Object value)
        {
            bool valueChanged = false;

            // If the key exists
            if (settings.Contains(Key))
            {
                // If the value has changed
                if (settings[Key] != value)
                {
                    // Store the new value
                    settings[Key] = value;
                    valueChanged = true;
                }
            }
            // Otherwise create the key.
            else
            {
                settings.Add(Key, value);
                valueChanged = true;
            }
            return valueChanged;
        }

        /// <summary>
        /// Get the current value of the setting, or if it is not found, set the 
        /// setting to the default setting.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public T GetValueOrDefault<T>(string Key, T defaultValue)
        {
            T value;

            // If the key exists, retrieve the value.
            if (settings.Contains(Key))
            {
                value = (T)settings[Key];
            }
            // Otherwise, use the default value.
            else
            {
                value = defaultValue;
            }
            return value;
        }        

        /// <summary>
        /// Save the settings.
        /// </summary>
        public void Save()
        {
            settings.Save();
        }

        /// <summary>
        /// Property to get and set a Api Key Setting Key.
        /// </summary>
        public string ApiKeySetting
        {
            get
            {
                return GetValueOrDefault<string>(ApiKeyKeyName, ApiKeySettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(ApiKeyKeyName, value))
                {
                    Save();
                }
            }
        }

        /// <summary>
        /// Property to get and set a Host Setting Key.
        /// </summary>
        public string HostSetting
        {
            get
            {
                return GetValueOrDefault<string>(HostKeyName, HostSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(HostKeyName, value))
                {
                    Save();
                }
            }
        }

        /// <summary>
        /// Property to get and set a Port Setting Key.
        /// </summary>
        public string PortSetting
        {
            get
            {
                return GetValueOrDefault<string>(PortKeyName, PortSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(PortKeyName, value))
                {
                    Save();
                }
            }
        }
    }
}