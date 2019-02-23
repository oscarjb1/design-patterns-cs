using System;

/**
 * @author Oscar Javier Blancarte Iturralde.
 * @see http://oscarblancarteblog.com
 */
    namespace oscarblancarte.ipd.facade.subsystems.biller{
    public class BillingPayRequest {

        private Int64 customerId;
        private double amount;

        public BillingPayRequest(Int64 customerId, double amount) {
            this.customerId = customerId;
            this.amount = amount;
        }

        public Int64 getCustomerId() {
            return customerId;
        }

        public void setCustomerId(Int64 customerId) {
            this.customerId = customerId;
        }

        public double getAmount() {
            return amount;
        }

        public void setAmount(double amount) {
            this.amount = amount;
        }

    }
}


