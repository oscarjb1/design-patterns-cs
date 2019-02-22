/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://wwww.oscarblancarteblog.com
 */
 
namespace oscarblancarte.ipd.adapter.creditapi.bankx{

    public class XBankCreditRequest {
        private string customerName;
        private double requestAmount;

        public string getCustomerName() {
            return customerName;
        }

        public void setCustomerName(string customerName) {
            this.customerName = customerName;
        }

        public double getRequestAmount() {
            return requestAmount;
        }

        public void setRequestAmount(double requestAmount) {
            this.requestAmount = requestAmount;
        }
    }
}
