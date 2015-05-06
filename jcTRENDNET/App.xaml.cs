using jcTRENDNET.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=402347&clcid=0x409

namespace jcTRENDNET
{   
    sealed partial class App : Common.BootStrapper
    {
        public App() : base()
        {
            this.InitializeComponent();
        }

        public static List<StoredCameraResponseItem> Cameras;

        public override Task OnInitializeAsync()
        {
            Cameras = new List<StoredCameraResponseItem>();

            Cameras.Add(new StoredCameraResponseItem
            {
                Description = "Test",
                ID = Guid.NewGuid(),
                IPAddress = "192.168.1.120"
            });

            Cameras.Add(new StoredCameraResponseItem
            {
                Description = "Test 2",
                ID = Guid.NewGuid(),
                IPAddress = "192.168.1.202"
            });

            Cameras.Add(new StoredCameraResponseItem
            {
                Description = "Test 3",
                ID = Guid.NewGuid(),
                IPAddress = "192.168.1.58"
            });

            Cameras.Add(new StoredCameraResponseItem
            {
                Description = "Test 4",
                ID = Guid.NewGuid(),
                IPAddress = "192.168.1.166"
            });

            Window.Current.Content = new Views.Shell(this.RootFrame);
            return base.OnInitializeAsync();
        }

        public override Task OnLaunchedAsync(ILaunchActivatedEventArgs e)
        {
            this.NavigationService.Navigate(typeof(Views.MainPage));
            return Task.FromResult<object>(null);
        }
    }
}