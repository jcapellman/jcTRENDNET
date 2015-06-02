using jcTRENDNET.Objects;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using jcTRENDNET.Common;
using jcTRENDNET.LocalDataManager;

namespace jcTRENDNET {
    sealed partial class App : Common.BootStrapper {
        public static SettingsManager SettingManager;
        public static CameraManager Cameras;

        public static LiveCameraResponseItem SelectedLiveCameraResponseItem;

        public App() : base() {
            this.InitializeComponent();

            SettingManager = new SettingsManager();
            Cameras = new CameraManager();
        }

        public override Task OnInitializeAsync() {
            if (!Cameras.GetAllCameras().Any()) {
                Cameras.AddCamera(new StoredCameraResponseItem {
                    Description = "Test",
                    ID = Guid.NewGuid(),
                    IPAddress = "192.168.1.120"
                });

                Cameras.AddCamera(new StoredCameraResponseItem {
                    Description = "Test 2",
                    ID = Guid.NewGuid(),
                    IPAddress = "192.168.1.202"
                });

                Cameras.AddCamera(new StoredCameraResponseItem {
                    Description = "Test 3",
                    ID = Guid.NewGuid(),
                    IPAddress = "192.168.1.58"
                });

                Cameras.AddCamera(new StoredCameraResponseItem {
                    Description = "Test 4",
                    ID = Guid.NewGuid(),
                    IPAddress = "192.168.1.166"
                });
            }

            Window.Current.Content = new Views.Shell(this.RootFrame);
            return base.OnInitializeAsync();
        }

        public override Task OnLaunchedAsync(ILaunchActivatedEventArgs e) {
            this.NavigationService.Navigate(typeof(Views.MainPage));
            return Task.FromResult<object>(null);
        }
    }
}