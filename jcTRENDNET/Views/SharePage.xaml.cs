using Windows.UI.Xaml.Controls;

using jcTRENDNET.Viewmodels;
using Windows.UI.Xaml.Navigation;
using jcTRENDNET.Objects;

namespace jcTRENDNET.Views {
    public sealed partial class SharePage : Page {
        private ShareModel viewModel => (ShareModel)DataContext;

        public SharePage() {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            DataContext = new ShareModel();

            viewModel.Camera = (LiveCameraResponseItem)e.Parameter;

            base.OnNavigatedTo(e);
        }
    }
}