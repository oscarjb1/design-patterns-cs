using oscarblancarte.ipd.facade.util;
using System;

/**
 * @author Oscar Javier Blancarte Iturralde.
 * @see http://oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.facade.subsystems.biller{
    public class BillingSystem {

        public double queryCustomerBalance(Int64 customerId) {
            Customer customer = OnMemoryDataBase.findCustomerById(customerId);
            return customer.getBalance();
        }

        public double pay(BillingPayRequest billingPay) {
            Customer customer = OnMemoryDataBase.findCustomerById(billingPay.getCustomerId());
            customer.setBalance(customer.getBalance() - billingPay.getAmount());
            Console.WriteLine("Payment applied to the client '"+customer.getName()+"', "
                    + "the new balance is '"+customer.getBalance()+"'");
            return customer.getBalance();//new Balance.
        }
    }
}




