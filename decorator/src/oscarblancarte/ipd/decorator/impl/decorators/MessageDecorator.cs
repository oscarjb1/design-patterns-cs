using oscarblancarte.ipd.decorator.impl.message;

/**
 *
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.decorator.impl.decorators{
    public abstract class MessageDecorator : IMessage {
        protected IMessage Message;

        public MessageDecorator(IMessage message) {
            this.Message = message;
        }

        public void SetContent(string content) {
            Message.SetContent(content);
        }

        public string GetContent() {
            return Message.GetContent();
        }

        public abstract IMessage ProcessMessage();
    }
}