using System;

/**
 *
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.decorator.impl.message{
    public class CustomerMessage : IMessage {

        public string Name{get; set;}
        public string Email{get; set;}
        public string Telephone{get; set;}

        public CustomerMessage() {
        }

        public CustomerMessage(string name, string email, string telephone) {
            this.Name = name;
            this.Email = email;
            this.Telephone = telephone;
        }

        public IMessage ProcessMessage() {
            return this;
        }

        public string GetContent() {
            return ToString();
        }

        public override string ToString() {
            return "CustomerMessage{" + "name=" + Name + ", \nemail=" + Email + ", telephone=" + Telephone + '}';
        }

        public void SetContent(string content) {
            throw new NotSupportedException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
        }
    }
}


