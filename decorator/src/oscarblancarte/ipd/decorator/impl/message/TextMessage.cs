/**
 *
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.decorator.impl.message{
    public class TextMessage : IMessage {

        private string Content;

        public TextMessage() {
        }

        public TextMessage(string message) {
            this.Content = message;
        }

        public string GetMessage() {
            return Content;
        }

        public void SetMessage(string message) {
            this.Content = message;
        }

        public IMessage ProcessMessage() {
            return this;
        }

        public string GetContent() {
            return Content;
        }

        public void SetContent(string content) {
            this.Content = content;
        }
    }
}


