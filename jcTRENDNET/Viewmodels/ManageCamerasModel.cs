using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;

using jcTRENDNET.Objects;

namespace jcTRENDNET.Viewmodels {
    public class ManageCamerasModel : INotifyPropertyChanged {
        private readonly HttpClient _httpClient;

        public ManageCamerasModel() {
            _httpClient = new HttpClient();
        }

        public ObservableCollection<StoredCameraResponseItem> LiveCameras {
            get { return App.Cameras; }

            set {
                App.Cameras = value;
                OnPropertyChanged();
            }
        }

        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}