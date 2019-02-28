/**
 *
 * @author oblancarte
 */
    namespace oscarblancarte.ipd.builder.dto{
    public class Contact {
        public string Name{get; set;}
        public Phone Phone{get; set;}
        public Address Address{get; set;}

        public Contact() {
        }

        public Contact(string name, Phone phone,Address address) {
            this.Name = name;
            this.Phone = phone;
        }
        
        public Contact(string name, Phone phone) {
            this.Name = name;
            this.Phone = phone;
        }

        

        public override string ToString() {
            return "Contact{" + "name=" + Name + ", phone=" + Phone + '}';
        }
    }
}


