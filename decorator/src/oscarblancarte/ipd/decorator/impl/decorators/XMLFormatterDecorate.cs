// using java.io.ByteArrayOutputStream;
// using javax.xml.bind.JAXBContext;
// using javax.xml.bind.JAXBElement;
// using javax.xml.bind.Marshaller;
// using javax.xml.namespace.QName;
using oscarblancarte.ipd.decorator.impl.message;
using System;  
using System.Xml;  
using System.Xml.Serialization;  
using System.IO;  

/**
 *
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.decorator.impl.decorators{
    public class XMLFormatterDecorate : MessageDecorator {

        public XMLFormatterDecorate(IMessage message) : base(message){
            
        }

        public override IMessage ProcessMessage() {
            Message = Message.ProcessMessage();
            Message = XmlMessage();
            return Message;
        }

        private IMessage XmlMessage() {
            try {
                //JAXBContext jc = JAXBContext.newInstance(message.getClass());
                //JAXBElement<IMessage> je2 = new JAXBElement<IMessage>(new QName(message.getClass().getName()), (Class<IMessage>) message.getClass(), message);
                //Marshaller marshaller = jc.createMarshaller();
                //marshaller.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, true);
                //ByteArrayOutputStream output = new ByteArrayOutputStream();
                //marshaller.marshal(je2, output);
                //return new TextMessage(new String(output.toByteArray()));
                
                XmlSerializer xmlSerializer = new XmlSerializer(Message.GetType());  
                
                using(StringWriter textWriter = new StringWriter())
                {
                    xmlSerializer.Serialize(textWriter, Message);
                    return new TextMessage(textWriter.ToString());
                }

                throw new SystemException();

            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                throw new SystemException("XML error converting");
            }
        }
    }
}




