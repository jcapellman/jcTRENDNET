using System;
using System.Collections.Generic;
using jcTRENDNET.Objects;

namespace jcTRENDNET.LocalDataManager {
    public class CameraManager : BaseManager {
        internal override T getDefault<T>(string key) {
            return default(T);
        }

        public void AddCamera(StoredCameraResponseItem obj) {
            AddValue(obj.ID.ToString(), obj);
        }

        public StoredCameraResponseItem GetCamera(Guid id) {
            return GetValue<StoredCameraResponseItem>(id.ToString());
        }

        public bool RemoveCamera(Guid id) {
            return RemoveValue(id.ToString());
        }

        public List<StoredCameraResponseItem> GetAllCameras() {
            return this.GetAll<StoredCameraResponseItem>();
        } 
    }
}