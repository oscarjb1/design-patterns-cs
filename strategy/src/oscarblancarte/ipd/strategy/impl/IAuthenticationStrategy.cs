/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.strategy.impl{
    public interface IAuthenticationStrategy {
        
        Principal authenticate(string userName, string passwrd);
    }
}