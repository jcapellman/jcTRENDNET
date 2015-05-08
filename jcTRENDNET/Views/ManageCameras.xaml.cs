using Windows.UI.Xaml.Controls;

using jcTRENDNET.Viewmodels;

namespace jcTRENDNET.Views {
    public sealed partial class ManageCameras : Page {
        public ManageCameras() {
            this.InitializeComponent();

            DataContext = new ManageCamerasModel();
        }
    }
}