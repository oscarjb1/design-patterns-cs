using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.proxy.services{
    public class AuditService {
        public void auditServiceUsed(string user, string service){
            Console.WriteLine(user + " used the service > " + service + ", at " + DateTime.Now.ToString("yyyyMMddHHmmss"));
        }
    }
}




