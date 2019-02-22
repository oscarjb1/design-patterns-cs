/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://wwww.oscarblancarteblog.com
 */

namespace oscarblancarte.ipd.adapter.impl{
    public class BankCreditRequest {
        private string customer;
        private double amount;

        public string getCustomer() {
            return customer;
        }

        public void setCustomer(string customer) {
            this.customer = customer;
        }

        public double getAmount() {
            return amount;
        }

        public void setAmount(double amount) {
            this.amount = amount;
        }
    }
}


