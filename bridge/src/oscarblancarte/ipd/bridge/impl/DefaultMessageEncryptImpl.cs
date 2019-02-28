using oscarblancarte.ipd.bridge.encript;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.bridge.impl{
    public class DefaultMessageEncryptImpl : IMessageEncrypt{
        private IEncryptAlgorithm EncryptAlgorith;
        
        public DefaultMessageEncryptImpl(IEncryptAlgorithm encryptAlgorith){
            this.EncryptAlgorith = encryptAlgorith;
        }
        
        public string EncryptMessage(string message, string password) {
            return EncryptAlgorith.Encrypt(message, password);
        }
    }
}



