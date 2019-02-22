/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.bridge.impl{
    public interface IMessageEncrypt {
        string encryptMessage(string message, string password);
    }
}