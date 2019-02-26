namespace oscarblancarte.ipd.nullobject.domain{
    public class Address {

        public static readonly Address NULL_ADDRESS = new Address("NOT ADDRESS") ;  

        public string fullAddress;

        public Address(string fullAddress) {
            this.fullAddress = fullAddress;
        }

        public Address() {
        }

        public string getFullAddress() {
            return fullAddress;
        }

        public void setFullAddress(string fullAddress) {
            this.fullAddress = fullAddress;
        }
    }

}

