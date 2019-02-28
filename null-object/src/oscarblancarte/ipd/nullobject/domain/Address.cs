namespace oscarblancarte.ipd.nullobject.domain{
    public class Address {

        public static readonly Address NULL_ADDRESS = new Address("NOT ADDRESS") ;  

        public string FullAddress{get; set;}

        public Address(string FullAddress) {
            this.FullAddress = FullAddress;
        }

        public Address() {
        }
    }
}