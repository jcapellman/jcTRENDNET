namespace jcTRENDNET.LocalDataManager {
    public class CameraManager : BaseManager {
        internal override T getDefault<T>(string key) {
            return default(T);
        }
    }
}