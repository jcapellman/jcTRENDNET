using Windows.UI.Xaml.Controls;

using jcTRENDNET.Viewmodels;

namespace jcTRENDNET.Views {
    public sealed partial class SharePage : Page {
        public SharePage() {
            this.InitializeComponent();

            DataContext = new ShareModel();
        }
    }
}