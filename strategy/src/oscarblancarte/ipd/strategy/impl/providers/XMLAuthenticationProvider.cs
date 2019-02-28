using oscarblancarte.ipd.strategy.impl;
using System;
using System.Text;
using System.Xml;
/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.strategy.impl.providers{
    public class XMLAuthenticationProvider : IAuthenticationStrategy {

        private static readonly string RolXPath = "descendant::User[@userName='{0}' and @password='{1}']/@rol";
        public Principal Authenticate(string userName, string passwrd) {
            try {
                XmlDocument doc = new XmlDocument();  
                doc.Load("./UserFile.xml");  
                XmlNode root = doc.DocumentElement;  
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);  
                //nsmgr.AddNamespace("bk", "urn:newbooks-schema");  
                
                string xpath = string.Format(RolXPath, userName,passwrd);
                XmlNode node = root.SelectSingleNode(xpath, nsmgr);  
                if(node == null){
                    return null;
                }
                string rol = node.InnerXml;
                if(rol!=null && !(rol.Length == 0)){
                    return new Principal(userName, rol);
                }
                return null;
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}


