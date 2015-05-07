using System;
using Windows.UI.Xaml.Navigation;

namespace jcTRENDNET.Services {
    public class NavigationEventArgs : EventArgs {
        public NavigationMode NavigationMode { get; set; }

        public string Parameter { get; set; }
    }
}