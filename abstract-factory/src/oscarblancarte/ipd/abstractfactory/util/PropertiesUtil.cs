using System.IO;
using System.Collections.Generic;
using Authlete.Util;
using System;
/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.abstractfactory.util{
    public class PropertiesUtil {
        public static IDictionary<string,string> LoadProperty(string propertiesURL){
            try {
                IDictionary<string, string> prop = null;
                using (TextReader reader = new StreamReader(propertiesURL))
                {
                    prop = PropertiesLoader.Load(reader);
                }
                return prop;
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}