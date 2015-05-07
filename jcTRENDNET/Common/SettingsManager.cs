namespace jcTRENDNET.Common {
    public class SettingsManager {
        readonly Windows.Storage.ApplicationDataContainer _roamingSettings = Windows.Storage.ApplicationData.Current.RoamingSettings;
        
        public void AddValue<T>(string key, T objVal) {
            _roamingSettings.Values[key] = objVal;
        }

        public T GetValue<T>(string key) {
            var objVal = _roamingSettings.Values[key];

            if (objVal == null) {
                return default(T);
            }

            if (typeof (T) != typeof (bool)) {
                return (T) objVal;
            }

            object tmp = objVal.ToString().ToLower() != "false";

            return (T)tmp;
        }
    }
}