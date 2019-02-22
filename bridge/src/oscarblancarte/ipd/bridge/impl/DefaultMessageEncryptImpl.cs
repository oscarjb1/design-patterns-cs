using oscarblancarte.ipd.bridge.encript;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.bridge.impl{
    public class DefaultMessageEncryptImpl : IMessageEncrypt{
        private IEncryptAlgorithm encryptAlgorith;
        
        public DefaultMessageEncryptImpl(IEncryptAlgorithm encryptAlgorith){
            this.encryptAlgorith = encryptAlgorith;
        }
        
        public string encryptMessage(string message, string password) {
            return encryptAlgorith.encrypt(message, password);
        }
    }
}



