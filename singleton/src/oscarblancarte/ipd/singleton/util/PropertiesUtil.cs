using System.Configuration;
using System.Collections.Specialized;
using System;

/**
 * @author oblancarte
 */

namespace oscarblancarte.ipd.singleton.util{
    public class PropertiesUtil {
        public static NameValueCollection LoadProperty(){
            try {
                NameValueCollection props = ConfigurationManager.AppSettings;
                return props;
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}




