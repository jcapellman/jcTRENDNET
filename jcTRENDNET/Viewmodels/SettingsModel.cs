using System.ComponentModel;
using System.Runtime.CompilerServices;

using jcTRENDNET.Common;
using jcTRENDNET.LocalDataManager;

namespace jcTRENDNET.Viewmodels {
    public class SettingsModel : INotifyPropertyChanged {
        public bool Setting_EnableCompression {
            get { return App.SettingManager.GetValue<bool>(SettingsManager.SETTINGS_ENUM.Enable_Compression); }

            set {
                App.SettingManager.AddValue(SettingsManager.SETTINGS_ENUM.Enable_Compression, value);
                OnPropertyChanged();
            }
        }

        public int Setting_AutomaticRefresh {
            get { return App.SettingManager.GetValue<int>(SettingsManager.SETTINGS_ENUM.Automatic_Refresh); }

            set {
                App.SettingManager.AddValue(SettingsManager.SETTINGS_ENUM.Automatic_Refresh, value);
                OnPropertyChanged();
            }
        }

        public int Setting_Timeout {
            get { return App.SettingManager.GetValue<int>(SettingsManager.SETTINGS_ENUM.Timeout); }

            set {
                App.SettingManager.AddValue(SettingsManager.SETTINGS_ENUM.Timeout, value);
                OnPropertyChanged();
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
