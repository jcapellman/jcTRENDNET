using Windows.UI.Xaml.Controls;

using jcTRENDNET.Viewmodels;

namespace jcTRENDNET.Views {
    public sealed partial class SettingsPage : Page {
        public SettingsPage() {
            this.InitializeComponent();

            DataContext = new SettingsModel();
        }
    }
}