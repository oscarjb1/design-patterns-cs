using oscarblancarte.ipd.strategy.impl;
using oscarblancarte.ipd.strategy.util;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.strategy.impl.providers{

}

public class OnMemoryAuthenticationProvider : IAuthenticationStrategy{

    public Principal Authenticate(string userName, string passwrd) {
        User user = OnMemoryDataBase.FindUserByName(userName);
        if(user!=null && user.Password.Equals(passwrd)){
            return new Principal(user.UserName, user.Rol);
        }
        return null;
    }
}