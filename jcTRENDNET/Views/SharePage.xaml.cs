using System;
using Windows.UI.Xaml.Controls;

using jcTRENDNET.Viewmodels;
using Windows.UI.Xaml.Navigation;
using jcTRENDNET.Objects;
using System.Collections.Generic;
using Windows.Storage.Streams;
using Windows.ApplicationModel.DataTransfer;

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

        private async void abbSave_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e) {
            var savePicker = new Windows.Storage.Pickers.FileSavePicker();

            savePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;

            savePicker.FileTypeChoices.Add("JPEG", new List<string>() { ".jpg" });

            savePicker.SuggestedFileName = viewModel.Camera.Description.Replace(" ", "-") + "_" + DateTime.Now.ToString().Replace(" ", "_") + ".jpg";

            var file = await savePicker.PickSaveFileAsync();

            if (file == null) {
                return;
            }

            Windows.Storage.CachedFileManager.DeferUpdates(file);

            await Windows.Storage.FileIO.WriteBytesAsync(file, viewModel.Camera.RawData);
            await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);
        }

        private void abbShare_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e) {
            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += DataTransferManager_DataRequested;

            DataTransferManager.ShowShareUI();
        }

        private void DataTransferManager_DataRequested(DataTransferManager sender, DataRequestedEventArgs args) {
            DataRequest request = args.Request;

            RandomAccessStreamReference imageStream = RandomAccessStreamReference.CreateFromUri(viewModel.Camera.Data.UriSource);

            request.Data.SetBitmap(imageStream);
        }
    }
}