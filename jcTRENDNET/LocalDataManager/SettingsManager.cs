using System;

namespace jcTRENDNET.LocalDataManager {
    public class SettingsManager : BaseManager {
        public enum SETTINGS_ENUM {
            Enable_Compression,
            Automatic_Refresh,
            Timeout
        }
        
        internal override T getDefault<T>(string setting) {
            return getDefault<T>((SETTINGS_ENUM)Enum.Parse(typeof(SETTINGS_ENUM), setting, true));
        }

        internal override T ConvertGeneric<T>(string strVal) {
            return (T)Convert.ChangeType(strVal, typeof(T));
        }

        private T getDefault<T>(SETTINGS_ENUM setting) {
            switch (setting) {
                case SETTINGS_ENUM.Automatic_Refresh:
                    return (T)Convert.ChangeType(5, typeof(int));
                case SETTINGS_ENUM.Enable_Compression:
                    return (T)Convert.ChangeType(true, typeof(bool));
                case SETTINGS_ENUM.Timeout:
                    return (T)Convert.ChangeType(30, typeof(int));
            }

            return default(T);
        }

        public void AddValue<T>(SETTINGS_ENUM setting, T objVal) {
            AddValue<T>(setting.ToString(), objVal);
        }
        
        public T GetValue<T>(SETTINGS_ENUM setting) {
            return GetValue<T>(setting.ToString());
        }
    }
}