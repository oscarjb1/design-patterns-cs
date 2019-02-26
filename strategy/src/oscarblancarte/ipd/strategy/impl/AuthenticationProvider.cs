using System;
/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.strategy.impl{
    public class AuthenticationProvider {
        private IAuthenticationStrategy authenticationStrategy;
        
        public void setAuthenticationStrategy(IAuthenticationStrategy strategy){
            this.authenticationStrategy = strategy;
        }
        
        public Principal authenticate(String userName, String password){
            if(authenticationStrategy==null){
                throw new SystemException("Strategy not found");
            }
            return authenticationStrategy.authenticate(userName, password);
        }
    }
}


