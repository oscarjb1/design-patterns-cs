/**
 *
 * @author oblancarte
 */
    namespace oscarblancarte.ipd.builder.dto{
    public class Contact {
        private string name;
        private Phone phone;
        private Address address;

        public Contact() {
        }

        public Contact(string name, Phone phone,Address address) {
            this.name = name;
            this.phone = phone;
        }
        
        public Contact(string name, Phone phone) {
            this.name = name;
            this.phone = phone;
        }

        public Address getAddress() {
            return address;
        }

        public void setAddress(Address address) {
            this.address = address;
        }
        
        public string getName() {
            return name;
        }

        public void setName(string name) {
            this.name = name;
        }

        public Phone getPhone() {
            return phone;
        }

        public void setPhone(Phone phone) {
            this.phone = phone;
        }

        public override string ToString() {
            return "Contact{" + "name=" + name + ", phone=" + phone + '}';
        }
    }
}


