/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.proxy.impl{
    public class ServiceFactory {
        
        public static IProcessEjecutor createProcessEjecutor(){
            return new ProcessEjecutorProxy();
        }
    }
}


