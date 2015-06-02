using Windows.UI.Xaml.Controls;

using jcTRENDNET.Viewmodels;
using jcTRENDNET.Objects;

namespace jcTRENDNET.Views {
    public partial class LiveCameraPage : Page {
        private LiveViewModel viewModel {
            get { return (LiveViewModel) DataContext; }
        }

        public LiveCameraPage() { 
            DataContext = new LiveViewModel();

            viewModel.LoadData();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            App.SelectedLiveCameraResponseItem = (LiveCameraResponseItem)lvCameras.SelectedItem;

            var nav = (App.Current as App).NavigationService;

            nav.Navigate(typeof(SharePage));
        }
    }
}