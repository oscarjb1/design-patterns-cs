/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.chainofresponsability.domain{
    public class Address {

        private string address1;
        private string address2;
        private string country;
        private string CP;

        public string getAddress1() {
            return address1;
        }

        public void setAddress1(string address1) {
            this.address1 = address1;
        }

        public string getAddress2() {
            return address2;
        }

        public void setAddress2(string address2) {
            this.address2 = address2;
        }

        public string getCountry() {
            return country;
        }

        public void setCountry(string country) {
            this.country = country;
        }

        public string getCP() {
            return CP;
        }

        public void setCP(string CP) {
            this.CP = CP;
        }
    }

}