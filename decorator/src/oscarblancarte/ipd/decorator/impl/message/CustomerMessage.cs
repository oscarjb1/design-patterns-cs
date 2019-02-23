using System;

/**
 *
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.decorator.impl.message{
    public class CustomerMessage : IMessage {

        private string name;
        private string email;
        private string telephone;

        public CustomerMessage() {
        }

        public CustomerMessage(string name, string email, string telephone) {
            this.name = name;
            this.email = email;
            this.telephone = telephone;
        }

        public string getName() {
            return name;
        }

        public void setName(string name) {
            this.name = name;
        }

        public string getEmail() {
            return email;
        }

        public void setEmail(string email) {
            this.email = email;
        }

        public string getTelephone() {
            return telephone;
        }

        public void setTelephone(string telephone) {
            this.telephone = telephone;
        }

        public IMessage processMessage() {
            return this;
        }

        public string getContent() {
            return ToString();
        }

        public override string ToString() {
            return "CustomerMessage{" + "name=" + name + ", \nemail=" + email + ", telephone=" + telephone + '}';
        }

        public void setContent(string content) {
            throw new NotSupportedException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
        }
    }
}


