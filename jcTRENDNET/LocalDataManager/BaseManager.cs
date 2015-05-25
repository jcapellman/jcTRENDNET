using System;
using System.Collections.Generic;
using System.Linq;
using jcTRENDNET.Objects;

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

        internal abstract T ConvertGeneric<T>(string strVal);
        
        internal List<T> GetAll<T>() {
            return _roamingSettings.Values.Select(item => ConvertGeneric<T>(item.ToString())).ToList();
        }
    }
}