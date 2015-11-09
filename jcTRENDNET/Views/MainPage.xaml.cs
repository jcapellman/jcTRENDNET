using jcTRENDNET.Objects;

using Windows.UI.Xaml.Controls;

namespace jcTRENDNET.Views {
    public sealed partial class MainPage : Page {
        public MainPage() {
            this.InitializeComponent();

            DataContext = new Viewmodels.LiveViewModel();

            ((Viewmodels.LiveViewModel)DataContext).LoadData();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var selectedItem = ((ListView)sender).SelectedItem;

            if (selectedItem == null) {
                return;
            }

            Frame.Navigate(typeof(SharePage), (LiveCameraResponseItem)selectedItem);
        }
    }
}