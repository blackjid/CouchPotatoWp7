using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using cpwp7.Utilities;

namespace cpwp7
{
    public partial class SettingsPage : PhoneApplicationPage
    {
        public SettingsPage()
        {
            InitializeComponent();  
          
        }
        
        private void SaveSettings_Click(object sender, EventArgs e)
        {
            App.Current.Settings.CPHostSetting = cpServerHost_text.Text;
            App.Current.Settings.CPApiKeySetting = cpApiKey_text.Text;
            App.Current.Settings.CPPortSetting = cpPort_text.Text;


            App.Current.Settings.SBHostSetting = sbServerHost_text.Text;
            App.Current.Settings.SBApiKeySetting = sbApiKey_text.Text;
            App.Current.Settings.SBPortSetting = sbPort_text.Text;        

            NavigationService.GoBack();
        }

        private void CancelSettings_Click(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}