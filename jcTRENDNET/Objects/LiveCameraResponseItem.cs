using System.Runtime.Serialization;
using Windows.UI.Xaml.Media.Imaging;

namespace jcTRENDNET.Objects {
    [DataContract]
    public class LiveCameraResponseItem {
        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public BitmapImage Data { get; set; }
    }
}