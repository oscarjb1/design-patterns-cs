/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.bridge.encript{
    public class NoEncryptAlgorithm : IEncryptAlgorithm{
        public string encrypt(string message, string password)  {
            return message;
        }
    }
}