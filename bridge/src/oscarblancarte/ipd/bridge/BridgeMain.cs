using oscarblancarte.ipd.bridge.encript;
using oscarblancarte.ipd.bridge.impl;
using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.bridge{
    public class BridgeMain {

        static void Main(string[] args) {
            IMessageEncrypt aesImpl = new DefaultMessageEncryptImpl(
                    new AESEncryptAlgorithm());
            IMessageEncrypt desImpl = new DefaultMessageEncryptImpl(
                    new DESEncryptAlgorithm());
            IMessageEncrypt noImpl = new DefaultMessageEncryptImpl(
                    new NoEncryptAlgorithm());
            
            try {
                string message = "<Person><Name>Oscar Blancarte</Name></Person>";
                string messageAES = aesImpl.encryptMessage(message, "HG58YZ3CR9123456");
                Console.WriteLine("messageAES > " + messageAES + "\n");
                
                string messageDES = desImpl.encryptMessage(message, "XMzDdG4D03CKm2Ix");
                Console.WriteLine("messageDES > " + messageDES + "\n");
                
                string messageNO = noImpl.encryptMessage(message, null);
                Console.WriteLine("messageNO > " + messageNO + "\n");
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
    }
}



