using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.chainofresponsability.domain{
    public abstract class Contributor {

        private string name;
        private string rfc;
        private Status status;
        
        private Address address;
        private Telephone telephone;
        private CreditData creditData;

        public CreditData getCreditData() {
            return creditData;
        }

        public void setCreditData(CreditData creditData) {
            this.creditData = creditData;
        }
        
        public string getName() {
            return name;
        }

        public void setName(string name) {
            this.name = name;
        }

        public string getRfc() {
            return rfc;
        }

        public void setRfc(string rfc) {
            this.rfc = rfc;
        }

        public Status getStatus() {
            return status;
        }

        public void setStatus(Status status) {
            this.status = status;
        }

        public Address getAddress() {
            return address;
        }

        public void setAddress(Address address) {
            this.address = address;
        }

        public Telephone getTelephone() {
            return telephone;
        }

        public void setTelephone(Telephone telephone) {
            this.telephone = telephone;
        }

    }

}


