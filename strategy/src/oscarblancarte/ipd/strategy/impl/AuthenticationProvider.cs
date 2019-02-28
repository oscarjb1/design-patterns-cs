using System;
/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.strategy.impl{
    public class AuthenticationProvider {
        private IAuthenticationStrategy AuthenticationStrategy;
        
        public void SetAuthenticationStrategy(IAuthenticationStrategy strategy){
            this.AuthenticationStrategy = strategy;
        }
        
        public Principal Authenticate(String userName, String password){
            if(AuthenticationStrategy==null){
                throw new SystemException("Strategy not found");
            }
            return AuthenticationStrategy.Authenticate(userName, password);
        }
    }
}


