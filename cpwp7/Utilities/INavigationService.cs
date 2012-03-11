using System;
using System.Windows.Navigation;

namespace cpwp7.Utilities
{
    // Only used in WP7
    public interface INavigationService
    {
        event NavigatingCancelEventHandler Navigating;
        void NavigateTo(Uri uri);
        void GoBack();
    }
}
