using oscarblancarte.ipd.proxy.impl;
using System;
/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.proxy{

    public class ProxyMain {

        static void Main(string[] args) {
            string user = "oblancarte";
            string password = "1234";
            int process = 1;
            IProcessEjecutor processEjecutor = ServiceFactory.CreateProcessEjecutor();
            try {
                processEjecutor.EjecuteProcess(process, user, password);
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
    }
}


