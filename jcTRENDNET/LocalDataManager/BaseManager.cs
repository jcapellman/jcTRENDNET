using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;
using System;

namespace jcTRENDNET.LocalDataManager {
    public abstract class BaseManager {
        readonly Windows.Storage.ApplicationDataContainer _roamingSettings = Windows.Storage.ApplicationData.Current.RoamingSettings;

        internal abstract T getDefault<T>(string key);

        private string serializeGeneric<T>(T obj) {
            return JsonConvert.SerializeObject(obj);
        }

        internal void AddValue<T>(string key, T objVal) {
            _roamingSettings.Values[typeof(T).FullName + "_" + key] = serializeGeneric(objVal);
        }

        internal T GetValue<T>(string key) {
            var objVal = _roamingSettings.Values[key];

            if (objVal == null) {
                objVal = getDefault<T>(key);

                AddValue(key, objVal);
            }
            
            if (typeof(T) == typeof(bool)) {
                return (T)Convert.ChangeType(objVal.ToString().ToUpper() == "TRUE", typeof(T));
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
            var keys = _roamingSettings.Values.Keys.Where(a => a.StartsWith(typeof(T).FullName + "_")).ToList();

            var data = new List<T>();

            foreach (var key in keys) {
                data.Add((T)JsonConvert.DeserializeObject<T>(_roamingSettings.Values.FirstOrDefault(a => a.Key == key).Value.ToString()));
            }

            return data;
        }
    }
}