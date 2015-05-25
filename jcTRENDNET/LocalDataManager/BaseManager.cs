namespace jcTRENDNET.LocalDataManager {
    public abstract class BaseManager {
        readonly Windows.Storage.ApplicationDataContainer _roamingSettings = Windows.Storage.ApplicationData.Current.RoamingSettings;

        internal abstract T getDefault<T>(string key);

        internal void AddValue<T>(string key, T objVal) {
            _roamingSettings.Values[key] = objVal;
        }

        internal T GetValue<T>(string key) {
            var objVal = _roamingSettings.Values[key];

            if (objVal == null) {
                objVal = getDefault<T>(key);

                AddValue(key, objVal);
            }

            if (typeof(T) != typeof(bool)) {
                return (T)objVal;
            }

            object tmp = objVal.ToString().ToLower() != "false";

            return (T)tmp;
        }
    }
}