using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Media.Imaging;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Storage.Streams;

using jcTRENDNET.Objects;

namespace jcTRENDNET.Viewmodels {
    public class LiveViewModel : INotifyPropertyChanged {
        private readonly HttpClient _httpClient;

        public LiveViewModel() { _httpClient = new HttpClient(); }

        private ObservableCollection<LiveCameraResponseItem> _liveCameras;

        public ObservableCollection<LiveCameraResponseItem> LiveCameras {
            get { return _liveCameras; }

            set { _liveCameras = value; OnPropertyChanged(); }
        }

        private async Task<bool> automaticRefresh() {
            while (true) {
                var result = await LoadCameras();

                if (result) {
                    continue;
                }

                return false;
            }
        }

        private async Task<bool> LoadCameras() {
            var couldNotConnect = new BitmapImage(new Uri(@"ms-resource://jcTRENDNET/Assets/CouldNotConnect.png", UriKind.RelativeOrAbsolute));

            foreach (var camera in App.Cameras) {
                var cameraView = new LiveCameraResponseItem { Description = camera.Description, CameraGUID = camera.ID};

                try {
                    var randomAccessStream = new InMemoryRandomAccessStream();

                    var urlAddress = $"http://{camera.IPAddress}/image/jpeg.cgi";

                    using (var responseStream = await _httpClient.GetStreamAsync(new Uri(urlAddress))) {
                        var buffer = new byte[500];

                        int read;

                        do {
                            read = await responseStream.ReadAsync(buffer, 0, buffer.Length);
                            await randomAccessStream.WriteAsync(buffer.AsBuffer());
                        } while (read != 0);

                        await randomAccessStream.FlushAsync();
                        randomAccessStream.Seek(0);
                    }

                    if (randomAccessStream.Size == 0) {
                        cameraView.Data = couldNotConnect;
                    } else {
                        var image = new BitmapImage();
                        await image.SetSourceAsync(randomAccessStream);

                        cameraView.Data = image;
                    }
                } catch (Exception) {
                    cameraView.Data = couldNotConnect;
                }

                cameraView.TimeStamp = DateTime.Now;

                var added = false;
                
                for (var x = 0; x < LiveCameras.Count; x++) {
                    if (LiveCameras[x].CameraGUID != camera.ID) {
                        continue;
                    }

                    LiveCameras.RemoveAt(x);
                    LiveCameras.Insert(x, cameraView);
                    added = true;
                }
                
                if (!added) {
                    LiveCameras.Add(cameraView);
                }
            }

            return true;
        }

        public async void LoadData() {
            LiveCameras = new ObservableCollection<LiveCameraResponseItem>();

            await LoadCameras();

            await automaticRefresh();
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