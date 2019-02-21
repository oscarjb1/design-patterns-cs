using java.io.InputStream;
using java.util.Properties;

/**
 * @author oblancarte
 */
namespace oscarblancarte.ipd.factorymethod.util{
    public class PropertiesUtil {
        public static Properties loadProperty(String propertiesURL){
            try {
                Properties properties = new Properties();
                InputStream inputStream = PropertiesUtil.class.getClassLoader().getResourceAsStream(propertiesURL);
                properties.load(inputStream);
                return properties;
            } catch (Exception e) {
                e.printStackTrace();
                return null;
            }
        }
    }
}