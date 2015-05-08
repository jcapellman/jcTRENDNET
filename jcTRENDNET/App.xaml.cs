﻿using jcTRENDNET.Objects;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

namespace jcTRENDNET {
    sealed partial class App : Common.BootStrapper {
        public App() : base() {
            this.InitializeComponent();
        }

        public static ObservableCollection<StoredCameraResponseItem> Cameras;

        public override Task OnInitializeAsync() {
            Cameras = new ObservableCollection<StoredCameraResponseItem>();

            Cameras.Add(new StoredCameraResponseItem {
                Description = "Test",
                ID = Guid.NewGuid(),
                IPAddress = "192.168.1.120"
            });

            Cameras.Add(new StoredCameraResponseItem {
                Description = "Test 2",
                ID = Guid.NewGuid(),
                IPAddress = "192.168.1.202"
            });

            Cameras.Add(new StoredCameraResponseItem {
                Description = "Test 3",
                ID = Guid.NewGuid(),
                IPAddress = "192.168.1.58"
            });

            Cameras.Add(new StoredCameraResponseItem {
                Description = "Test 4",
                ID = Guid.NewGuid(),
                IPAddress = "192.168.1.166"
            });

            Window.Current.Content = new Views.Shell(this.RootFrame);
            return base.OnInitializeAsync();
        }

        public override Task OnLaunchedAsync(ILaunchActivatedEventArgs e) {
            this.NavigationService.Navigate(typeof(Views.MainPage));
            return Task.FromResult<object>(null);
        }
    }
}