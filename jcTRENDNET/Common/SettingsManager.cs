using System;

namespace jcTRENDNET.Common {
    public class SettingsManager {
        public enum SETTINGS_ENUM {
            Enable_Compression,
            Automatic_Refresh,
            Timeout
        }

        readonly Windows.Storage.ApplicationDataContainer _roamingSettings = Windows.Storage.ApplicationData.Current.RoamingSettings;

        private T getDefault<T>(string setting) {
            return getDefault<T>((SETTINGS_ENUM)Enum.Parse(typeof(SETTINGS_ENUM), setting, true));
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

        public void AddValue<T>(string key, T objVal) {
            _roamingSettings.Values[key] = objVal;
        }

        public T GetValue<T>(SETTINGS_ENUM setting) {
            return GetValue<T>(setting.ToString());
        }

        public T GetValue<T>(string key) {
            var objVal = _roamingSettings.Values[key];

            if (objVal == null) {
                objVal = getDefault<T>(key);
                
                AddValue(key, objVal);
            }

            if (typeof (T) != typeof (bool)) {
                return (T) objVal;
            }

            object tmp = objVal.ToString().ToLower() != "false";

            return (T)tmp;
        }
    }
}