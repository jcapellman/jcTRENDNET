using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace jcTRENDNET.Objects {
    [DataContract]
    public class StoredCameraResponseItem {
        [DataMember]
        public Guid ID { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string IPAddress { get; set; }

        [DataMember]
        public bool IsInternalOnly { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        public StoredCameraResponseItem() {
            Description = String.Empty;
            IPAddress = String.Empty;
            Username = String.Empty;
            Password = String.Empty;
            IsInternalOnly = true;
        }

        public override string ToString() {
            using (var sw = new StringWriter()) {
                var serializer = new XmlSerializer(GetType());
                serializer.Serialize(sw, this);

                return sw.ToString();
            }
        }

        public StoredCameraResponseItem FromString(string cameraStr) {
            using (var sw = new StringReader(cameraStr)) {
                var serializer = new XmlSerializer(typeof(StoredCameraResponseItem));

                return (StoredCameraResponseItem)serializer.Deserialize(sw);
            }
        }
    }
}