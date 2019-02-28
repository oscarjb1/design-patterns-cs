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

        public string User{get; set;}
        public string Password{get; set;}

        public EncryptMessage(string user, string password, IMessage message) : base(message) {
            this.User = user;
            this.Password = password;
        }

        
        public override IMessage ProcessMessage() {
            this.Message = Message.ProcessMessage();
            this.Encript();
            return Message;
        }

        private IMessage Encript() {
            try {
                AesCryptoServiceProvider dataencrypt = new AesCryptoServiceProvider();  
                dataencrypt.BlockSize = 128;  
                dataencrypt.KeySize = 128;  
                dataencrypt.Key = System.Text.Encoding.UTF8.GetBytes(this.Password);  
                dataencrypt.IV = System.Text.Encoding.UTF8.GetBytes(this.Password);  
                dataencrypt.Padding = PaddingMode.PKCS7;  
                dataencrypt.Mode = CipherMode.CBC;  
                ICryptoTransform crypto1 = dataencrypt.CreateEncryptor(dataencrypt.Key, dataencrypt.IV);  
                byte[] encrypteddata = crypto1.TransformFinalBlock(Encoding.ASCII.GetBytes(this.Message.GetContent()), 0, this.Message.GetContent().Length);  
                crypto1.Dispose();  
                string encryptedValue = Convert.ToBase64String(encrypteddata, 0, encrypteddata.Length);
                Message.SetContent(encryptedValue);
                return Message;

            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                throw new SystemException();
            }
        }
    }
}