using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Media.Imaging;
using jcTRENDNET.Objects;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Storage.Streams;

namespace jcTRENDNET.Viewmodels {
    public class LiveViewModel : INotifyPropertyChanged {
        private readonly HttpClient _httpClient;

        public LiveViewModel() { _httpClient = new HttpClient(); }

        private ObservableCollection<LiveCameraResponseItem> _liveCameras;

        public ObservableCollection<LiveCameraResponseItem> LiveCameras {
            get { return _liveCameras; }

            set { _liveCameras = value; OnPropertyChanged(); }
        }

        public async void LoadData() {
            var couldNotConnect = new BitmapImage(new Uri(@"ms-resource://jcTRENDNET/Assets/CouldNotConnect.png", UriKind.RelativeOrAbsolute));

            var tmp = new List<LiveCameraResponseItem>();


            foreach (var camera in App.Cameras) {
                var cameraView = new LiveCameraResponseItem { Description = camera.Description };

                try {
                    var randomAccessStream = new InMemoryRandomAccessStream();

                    var urlAddress = String.Format("http://{0}/image/jpeg.cgi", camera.IPAddress);

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

                    if (randomAccessStream == null) {
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

                tmp.Add(cameraView);
            }

            LiveCameras = new ObservableCollection<LiveCameraResponseItem>(tmp);

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