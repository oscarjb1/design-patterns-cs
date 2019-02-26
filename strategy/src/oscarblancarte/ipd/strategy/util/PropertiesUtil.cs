using System.Configuration;
using System.Collections.Specialized;
using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.strategy.util{
    public class PropertiesUtil {
        public static NameValueCollection loadProperty(){
            try {
                //Properties properties = new Properties();
                NameValueCollection props = ConfigurationManager.AppSettings;
                return props;
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}




