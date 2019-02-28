using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.proxy.impl{
    public class DefaultProcessEjecutor : IProcessEjecutor {

        public void EjecuteProcess(int idProcess,string user,string password)  {
            Console.WriteLine("processes " + idProcess + " in action");
            Console.WriteLine("processes " + idProcess + " finished");
        }
    }
}


