using System;

/**
 * @author Oscar Javier Blancarte Iturralde.
 * @see http://oscarblancarteblog.com
 */
    namespace oscarblancarte.ipd.facade.subsystems.biller{
    public class BillingPayRequest {

        public Int64 CustomerId{get; set;}
        public double Amount{get; set;}

        public BillingPayRequest(Int64 customerId, double amount) {
            this.CustomerId = customerId;
            this.Amount = amount;
        }
    }
}