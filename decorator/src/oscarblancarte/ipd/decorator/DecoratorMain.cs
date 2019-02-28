using oscarblancarte.ipd.decorator.impl.decorators;
using oscarblancarte.ipd.decorator.impl.message;
using System;
/**
 *
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.decorator{
        public class DecoratorMain {

        static void Main(string[] args) {
                
                CustomerMessage customerMessage = new CustomerMessage(
                        "Oscar Blancarte", "oscarblancarte3@gmail.com", "554433445566");
                Console.WriteLine("Original Message ==> " + customerMessage);
                
                IMessage message1 = new EncryptMessage("user", "HG58YZ3CR9123456", 
                        new SOAPEnvelopMessage(
                        new XMLFormatterDecorate(customerMessage))).ProcessMessage();
                Console.WriteLine("message1 =====================================>\n" 
                        + message1.GetContent() + "\n\n");
                
                IMessage message2 = new SOAPEnvelopMessage(
                        new EncryptMessage("user", "HG58YZ3CR9123456",
                        new XMLFormatterDecorate(customerMessage))).ProcessMessage();
                Console.WriteLine("message2 =====================================>\n" 
                        + message2.GetContent());
        }
        
        }
}


