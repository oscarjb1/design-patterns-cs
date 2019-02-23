/**
 * @author Oscar Javier Blancarte Iturralde.
 * @see http://oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.facade.impl{
    public class PaymentResponse {

        private string paymentConfirmNumber;
        private double newBalance;
        private string customerStatus;

        public PaymentResponse(string paymentConfirmNumber, double newBalance, string customerStatus) {
            this.paymentConfirmNumber = paymentConfirmNumber;
            this.newBalance = newBalance;
            this.customerStatus = customerStatus;
        }

        public string getPaymentConfirmNumber() {
            return paymentConfirmNumber;
        }

        public void setPaymentConfirmNumber(string paymentConfirmNumber) {
            this.paymentConfirmNumber = paymentConfirmNumber;
        }

        public double getNewBalance() {
            return newBalance;
        }

        public void setNewBalance(double newBalance) {
            this.newBalance = newBalance;
        }

        public string getCustomerStatus() {
            return customerStatus;
        }

        public void setCustomerStatus(string customerStatus) {
            this.customerStatus = customerStatus;
        }

    }
}


