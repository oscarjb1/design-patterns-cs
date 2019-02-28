
/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.bridge.encript{
    public interface IEncryptAlgorithm {
        string Encrypt(string message, string password) ;
    }

}