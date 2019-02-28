/**
 * @author Oscar Javier Blancarte Iturralde.
 * @see http://oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.facade.impl{
    public class PaymentResponse {

        public string PaymentConfirmNumber{get; set;}
        public double NewBalance{get; set;}
        public string CustomerStatus{get; set;}

        public PaymentResponse(string paymentConfirmNumber, double newBalance, string customerStatus) {
            this.PaymentConfirmNumber = paymentConfirmNumber;
            this.NewBalance = newBalance;
            this.CustomerStatus = customerStatus;
        }
    }
}