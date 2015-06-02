using System.ComponentModel;
using System.Runtime.CompilerServices;

using jcTRENDNET.Objects;

namespace jcTRENDNET.Viewmodels {
    public class ShareModel : INotifyPropertyChanged {
        private LiveCameraResponseItem _responseItem;

        public ShareModel() {
            Camera = App.SelectedLiveCameraResponseItem;
        }

        public LiveCameraResponseItem Camera { get { return _responseItem;}  set { _responseItem = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}