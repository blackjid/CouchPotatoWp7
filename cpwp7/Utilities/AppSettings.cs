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
        const string CPApiKeyKeyName = "CPApiKeySetting";
        const string CPHostKeyName = "CPHostSetting";
        const string CPPortKeyName = "CPPortSetting";
        const string SBApiKeyKeyName = "SBApiKeySetting";
        const string SBHostKeyName = "SBHostSetting";
        const string SBPortKeyName = "SBPortSetting";

        // The default value of our settings
        const string CPApiKeySettingDefault = "7c9fad341b764a5f8c4781c76f3cbc24";
        const string CPHostSettingDefault = "nas.blackjid.info";
        const string CPPortSettingDefault = "5050";
        const string SBApiKeySettingDefault = "f5d6701f555447546b6030432d15e229";
        const string SBHostSettingDefault = "nas.blackjid.info";
        const string SBPortSettingDefault = "8081";

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
        /// Property to get and set a CouchPotato Api Key Setting Key.
        /// </summary>
        public string CPApiKeySetting
        {
            get
            {
                return GetValueOrDefault<string>(CPApiKeyKeyName, CPApiKeySettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(CPApiKeyKeyName, value))
                {
                    Save();
                }
            }
        }

        /// <summary>
        /// Property to get and set a CouchPotato Host Setting Key.
        /// </summary>
        public string CPHostSetting
        {
            get
            {
                return GetValueOrDefault<string>(CPHostKeyName, CPHostSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(CPHostKeyName, value))
                {
                    Save();
                }
            }
        }

        /// <summary>
        /// Property to get and set a CouchPotato Port Setting Key.
        /// </summary>
        public string CPPortSetting
        {
            get
            {
                return GetValueOrDefault<string>(CPPortKeyName, CPPortSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(CPPortKeyName, value))
                {
                    Save();
                }
            }
        }

        /// <summary>
        /// Property to get and set a SickBeard Api Key Setting Key.
        /// </summary>
        public string SBApiKeySetting
        {
            get
            {
                return GetValueOrDefault<string>(SBApiKeyKeyName, SBApiKeySettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(SBApiKeyKeyName, value))
                {
                    Save();
                }
            }
        }

        /// <summary>
        /// Property to get and set a SickBeard Host Setting Key.
        /// </summary>
        public string SBHostSetting
        {
            get
            {
                return GetValueOrDefault<string>(SBHostKeyName, SBHostSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(SBHostKeyName, value))
                {
                    Save();
                }
            }
        }

        /// <summary>
        /// Property to get and set a SickBeard Port Setting Key.
        /// </summary>
        public string SBPortSetting
        {
            get
            {
                return GetValueOrDefault<string>(SBPortKeyName, SBPortSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(SBPortKeyName, value))
                {
                    Save();
                }
            }
        }
    }
}