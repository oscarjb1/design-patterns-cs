using oscarblancarte.ipd.singleton.util;
using System.Collections.Specialized;

/**
 * @author oblancarte
 */
namespace oscarblancarte.ipd.singleton{
    public class ConfigurationSingleton {

        private static ConfigurationSingleton Singleton;

        private static readonly string CONFIGURATION_PROP = "META-INF/Configuration.properties";
        
        private static readonly string APP_NAME_PROP = "appName";
        private static readonly string APP_VERSION_PROP = "appVersion";

        public string AppName{get; set;}
        public string AppVersion{get; set;}

        private ConfigurationSingleton() {
            NameValueCollection props = PropertiesUtil.LoadProperty();

            this.AppName = props[APP_NAME_PROP];
            this.AppVersion = props[APP_VERSION_PROP];
        }


        private static void CreateInstance(){
            if(Singleton ==null){
                Singleton = new ConfigurationSingleton();
            }
        }

        public static ConfigurationSingleton GetInstance() {
            if(Singleton == null) {
                CreateInstance();
            }
            return Singleton;
        }

       

        public override string ToString() {
            return "ConfigurationSingleton{" + "appName=" + AppName + ", appVersion=" + AppVersion + '}';
        }
    }
}

