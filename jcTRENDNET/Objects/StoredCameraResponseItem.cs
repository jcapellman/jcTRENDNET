using System;
using System.Runtime.Serialization;

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
    }
}