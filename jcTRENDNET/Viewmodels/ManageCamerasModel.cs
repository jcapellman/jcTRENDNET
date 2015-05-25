using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using jcTRENDNET.Objects;

namespace jcTRENDNET.Viewmodels {
    public class ManageCamerasModel : INotifyPropertyChanged {
        public List<StoredCameraResponseItem> Cameras {
            get { return App.Cameras.GetAllCameras(); }

            set { OnPropertyChanged(); }
        } 

        public ManageCamerasModel() {
            
        }

        public bool DeleteCamera(Guid id) {
            return App.Cameras.RemoveCamera(id);
        }

        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}