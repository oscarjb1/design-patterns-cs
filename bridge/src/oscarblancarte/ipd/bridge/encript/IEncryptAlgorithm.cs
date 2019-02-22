
/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.bridge.encript{
    public interface IEncryptAlgorithm {
        string encrypt(string message, string password) ;
    }

}