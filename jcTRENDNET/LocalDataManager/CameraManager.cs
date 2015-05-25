using System;
using System.Collections.Generic;

using jcTRENDNET.Objects;

namespace jcTRENDNET.LocalDataManager {
    public class CameraManager : BaseManager {
        internal override T getDefault<T>(string key) {
            return default(T);
        }

        internal override T ConvertGeneric<T>(string strVal) {
            return (T)Convert.ChangeType(new StoredCameraResponseItem().FromString(strVal), typeof(T));
        }

        public void AddCamera(StoredCameraResponseItem obj) {
            AddValue(obj.ID.ToString(), obj.ToString());
        }

        public StoredCameraResponseItem GetCamera(Guid id) {
            var cameraStr = GetValue<string>(id.ToString());

            return new StoredCameraResponseItem().FromString(cameraStr);
        }

        public bool RemoveCamera(Guid id) {
            return RemoveValue(id.ToString());
        }

        public List<StoredCameraResponseItem> GetAllCameras() {
            return this.GetAll<StoredCameraResponseItem>();
        } 
    }
}