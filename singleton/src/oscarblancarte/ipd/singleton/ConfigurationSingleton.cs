using oscarblancarte.ipd.singleton.util;
using System.Collections.Specialized;

/**
 * @author oblancarte
 */
namespace oscarblancarte.ipd.singleton{
    public class ConfigurationSingleton {

        private static ConfigurationSingleton singleton;

        private static readonly string CONFIGURATION_PROP = "META-INF/Configuration.properties";
        
        private static readonly string APP_NAME_PROP = "appName";
        private static readonly string APP_VERSION_PROP = "appVersion";

        private string appName;
        private string appVersion;

        private ConfigurationSingleton() {
            NameValueCollection props = PropertiesUtil.loadProperty();

            this.appName = props[APP_NAME_PROP];
            this.appVersion = props[APP_VERSION_PROP];
        }


        private static void createInstance(){
            if(singleton ==null){
                singleton = new ConfigurationSingleton();
            }
        }

        public static ConfigurationSingleton getInstance() {
            if(singleton == null) {
                createInstance();
            }
            return singleton;
        }

        public string getAppName() {
            return appName;
        }

        public void setAppName(string appName) {
            this.appName = appName;
        }

        public string getAppVersion() {
            return appVersion;
        }

        public void setAppVersion(string appVersion) {
            this.appVersion = appVersion;
        }

        public override string ToString() {
            return "ConfigurationSingleton{" + "appName=" + appName + ", appVersion=" + appVersion + '}';
        }
    }
}

