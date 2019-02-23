using oscarblancarte.ipd.decorator.impl.message;

/**
 *
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.decorator.impl.decorators{
    public class SOAPEnvelopMessage : MessageDecorator {

        public SOAPEnvelopMessage(IMessage message) : base(message){
            
        }

        public override IMessage processMessage() {
            message.processMessage();
            message =  envelopMessage();
            return message;
        }

        private IMessage envelopMessage() {
            string soap = "<soapenv:Envelope xmlns:soapenv="
                    + "\n\"http://schemas.xmlsoap.org/soap/envelope/\" "
                    + "\nxmlns:ser=\"http://service.dishweb.cl.com/\">\n"
                    + "   <soapenv:Header/>\n"
                    + "   <soapenv:Body>\n"
                    + message.getContent()
                    + "\n"
                    + "   </soapenv:Body>\n"
                    + "</soapenv:Envelope>";
            message.setContent(soap);
            return message;
        }

    }
}

