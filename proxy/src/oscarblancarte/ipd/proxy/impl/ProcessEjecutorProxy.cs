using oscarblancarte.ipd.proxy.services;
using System;
/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.proxy.impl{
    public class ProcessEjecutorProxy : IProcessEjecutor {

        public void ejecuteProcess(int idProcess,string user,string password)  {
            SecurityService securityService = new SecurityService();
            if(!securityService.authorization(user, password)){
                throw new Exception("The user '" + user + "' does not have privileges to execute the process");
            }
            
            DefaultProcessEjecutor ejecutorProcess = new DefaultProcessEjecutor();
            ejecutorProcess.ejecuteProcess(idProcess, user, password);
            
            AuditService audit = new AuditService();
            audit.auditServiceUsed(user, typeof(DefaultProcessEjecutor).Name );
        }
    }
}




