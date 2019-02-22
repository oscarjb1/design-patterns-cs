using System.Security.Cryptography;
using System.Text;
using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.bridge.encript{
    public class AESEncryptAlgorithm : IEncryptAlgorithm {

        public string encrypt(string message, string password)  {

            AesCryptoServiceProvider dataencrypt = new AesCryptoServiceProvider();  
            dataencrypt.BlockSize = 128;  
            dataencrypt.KeySize = 128;  
            dataencrypt.Key = System.Text.Encoding.UTF8.GetBytes(password);  
            dataencrypt.IV = System.Text.Encoding.UTF8.GetBytes(password);  
            dataencrypt.Padding = PaddingMode.PKCS7;  
            dataencrypt.Mode = CipherMode.CBC;  
            ICryptoTransform crypto1 = dataencrypt.CreateEncryptor(dataencrypt.Key, dataencrypt.IV);  
            byte[] encrypteddata = crypto1.TransformFinalBlock(Encoding.ASCII.GetBytes(message), 0, message.Length);  
            crypto1.Dispose();  
            //return encrypteddata.ToString();  

            return Convert.ToBase64String(encrypteddata, 0, encrypteddata.Length);
            
        }
    }
}




