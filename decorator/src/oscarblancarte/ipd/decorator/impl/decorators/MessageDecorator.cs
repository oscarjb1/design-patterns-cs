using oscarblancarte.ipd.decorator.impl.message;

/**
 *
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.decorator.impl.decorators{
    public abstract class MessageDecorator : IMessage {
        protected IMessage message;

        public MessageDecorator(IMessage message) {
            this.message = message;
        }

        public void setContent(string content) {
            message.setContent(content);
        }

        public string getContent() {
            return message.getContent();
        }

        public abstract IMessage processMessage();
    }
}