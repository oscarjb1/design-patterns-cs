using oscarblancarte.ipd.proxy.services;
using System;
/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.proxy.impl{
    public class ProcessEjecutorProxy : IProcessEjecutor {

        public void EjecuteProcess(int idProcess,string user,string password)  {
            SecurityService securityService = new SecurityService();
            if(!securityService.Authorization(user, password)){
                throw new Exception("The user '" + user + "' does not have privileges to execute the process");
            }
            
            DefaultProcessEjecutor ejecutorProcess = new DefaultProcessEjecutor();
            ejecutorProcess.EjecuteProcess(idProcess, user, password);
            
            AuditService audit = new AuditService();
            audit.AuditServiceUsed(user, typeof(DefaultProcessEjecutor).Name );
        }
    }
}




