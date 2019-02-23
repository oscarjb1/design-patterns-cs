/**
 *
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.decorator.impl.message{
    public class TextMessage : IMessage {

        private string content;

        public TextMessage() {
        }

        public TextMessage(string message) {
            this.content = message;
        }

        public string getMessage() {
            return content;
        }

        public void setMessage(string message) {
            this.content = message;
        }

        public IMessage processMessage() {
            return this;
        }

        public string getContent() {
            return content;
        }

        public void setContent(string content) {
            this.content = content;
        }
    }
}


