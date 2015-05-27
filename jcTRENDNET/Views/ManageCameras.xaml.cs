using Windows.UI.Xaml.Controls;
using jcTRENDNET.Objects;
using jcTRENDNET.Viewmodels;

namespace jcTRENDNET.Views {
    public sealed partial class ManageCameras : Page {
        private ManageCamerasModel viewModel => (ManageCamerasModel) DataContext;

        public ManageCameras() {
            this.InitializeComponent();

            lvCameras.SelectionChanged += LvCameras_SelectionChanged;
            abbDelete.Tapped += AbbDelete_Tapped;

            DataContext = new ManageCamerasModel();
        }

        private void AbbDelete_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e) {
            viewModel.DeleteCamera(((StoredCameraResponseItem) lvCameras.SelectedItem).ID);
        }

        private void LvCameras_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (lvCameras.SelectedItem == null) {
                abbDelete.IsEnabled = false;
                return;
            }

            abbDelete.IsEnabled = true;
        }
    }
}