using oscarblancarte.ipd.strategy.impl;
using oscarblancarte.ipd.strategy.util;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.strategy.impl.providers{

}

public class OnMemoryAuthenticationProvider : IAuthenticationStrategy{

    public Principal authenticate(string userName, string passwrd) {
        User user = OnMemoryDataBase.findUserByName(userName);
        if(user!=null && user.getPassword().Equals(passwrd)){
            return new Principal(user.getUserName(), user.getRol());
        }
        return null;
    }
}