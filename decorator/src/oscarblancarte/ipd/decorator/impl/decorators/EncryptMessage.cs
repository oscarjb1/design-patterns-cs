using oscarblancarte.ipd.decorator.impl.message;
using System.Security.Cryptography;
using System.Text;
using System;
/**
 *
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.decorator.impl.decorators{
    public class EncryptMessage : MessageDecorator {

        private string user;
        private string password;

        public EncryptMessage(string user, string password, IMessage message) : base(message) {
            this.user = user;
            this.password = password;
        }

        public string getUser() {
            return user;
        }

        public void setUser(string user) {
            this.user = user;
        }

        public string getPassword() {
            return password;
        }

        public void setPassword(string password) {
            this.password = password;
        }

        public override IMessage processMessage() {
            this.message = message.processMessage();
            this.Encript();
            return message;
        }

        private IMessage Encript() {
            try {
                AesCryptoServiceProvider dataencrypt = new AesCryptoServiceProvider();  
                dataencrypt.BlockSize = 128;  
                dataencrypt.KeySize = 128;  
                dataencrypt.Key = System.Text.Encoding.UTF8.GetBytes(this.password);  
                dataencrypt.IV = System.Text.Encoding.UTF8.GetBytes(this.password);  
                dataencrypt.Padding = PaddingMode.PKCS7;  
                dataencrypt.Mode = CipherMode.CBC;  
                ICryptoTransform crypto1 = dataencrypt.CreateEncryptor(dataencrypt.Key, dataencrypt.IV);  
                byte[] encrypteddata = crypto1.TransformFinalBlock(Encoding.ASCII.GetBytes(this.message.getContent()), 0, this.message.getContent().Length);  
                crypto1.Dispose();  
                string encryptedValue = Convert.ToBase64String(encrypteddata, 0, encrypteddata.Length);
                message.setContent(encryptedValue);
                return message;

            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                throw new SystemException();
            }
        }
    }
}