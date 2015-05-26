using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

namespace jcTRENDNET.LocalDataManager {
    public abstract class BaseManager {
        readonly Windows.Storage.ApplicationDataContainer _roamingSettings = Windows.Storage.ApplicationData.Current.RoamingSettings;

        internal abstract T getDefault<T>(string key);

        private string serializeGeneric<T>(T obj) {
            return JsonConvert.SerializeObject(obj);
        }

        internal void AddValue<T>(string key, T objVal) {
            _roamingSettings.Values[key] = serializeGeneric(objVal);
        }

        internal T GetValue<T>(string key) {
            var objVal = _roamingSettings.Values[key];

            if (objVal == null) {
                objVal = getDefault<T>(key);

                AddValue(key, objVal);
            }

            return JsonConvert.DeserializeObject<T>(objVal.ToString());
        }

        internal bool RemoveValue(string key) {
            var obj = _roamingSettings.Values[key];

            if (obj == null) {
                return false;
            }

            _roamingSettings.Values.Remove(key);

            return true;
        }

        internal bool RemoveAll() {
            return true;
        }
        
        internal List<T> GetAll<T>() {
            return _roamingSettings.Values.Select(item => JsonConvert.DeserializeObject<T>(item.ToString())).ToList();
        }
    }
}