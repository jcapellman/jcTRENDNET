using System;
using System.Runtime.Serialization;
using Windows.UI.Xaml.Media.Imaging;

namespace jcTRENDNET.Objects {
    [DataContract]
    public class LiveCameraResponseItem {
        [DataMember]
        public Guid CameraGUID { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public BitmapImage Data { get; set; }

        [DataMember]
        public DateTime TimeStamp { get; set; }
    }
}