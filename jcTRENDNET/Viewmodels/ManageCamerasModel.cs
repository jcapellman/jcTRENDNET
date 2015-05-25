using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace jcTRENDNET.Viewmodels {
    public class ManageCamerasModel : INotifyPropertyChanged {
        public ManageCamerasModel() {
            
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