using oscarblancarte.ipd.facade.subsystems.bank;
using oscarblancarte.ipd.facade.subsystems.biller;
using oscarblancarte.ipd.facade.subsystems.crm;
using oscarblancarte.ipd.facade.subsystems.email;
using oscarblancarte.ipd.facade.util;
using System.Collections.Generic;
using System;

/**
 * @author Oscar Javier Blancarte Iturralde.
 * @see http://oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.facade.impl{
    public class OnlinePaymentFacadeImpl : IPaymentFacade {

        private static readonly CRMSystem crmSystem = new CRMSystem();
        private static readonly BillingSystem billingSyste = new BillingSystem();
        private static readonly BankSystem bankSyste = new BankSystem();
        private static readonly EmailSystem emailSenderSystem = new EmailSystem();
        
        
        public PaymentResponse pay(PaymentRequest request)  {
            Customer customer = crmSystem.findCustomer(request.getCustomerId());
            //Validate Set
            if(customer==null){
                throw new GeneralPaymentError("Customer ID does not exist '" +request.getCustomerId()+"' not exist.");
            }else if("Inactive".Equals(customer.getStatus()) ){
                throw new GeneralPaymentError("Customer ID does not exist '" +request.getCustomerId()+"' is inactive.");
            }else if(request.getAmmount() > billingSyste.queryCustomerBalance(customer.getId())){
                throw new GeneralPaymentError("You are trying to make a payment " + "\n\tgreater than the customer's balance");
            }
            
            //charge to the card
            TransferRequest transfer = new TransferRequest(
                    request.getAmmount(),request.getCardNumber(), 
                    request.getCardName(), request.getCardExpDate(), 
                    request.getCardNumber());
            string payReference = bankSyste.transfer(transfer);
            
            //Impact of the balance in the billing system
            BillingPayRequest billingRequest = new BillingPayRequest(
                    request.getCustomerId(), request.getAmmount());
            double newBalance = billingSyste.pay(billingRequest);
            
            //The client is reactivated if the new balance is less than $ 51
            string newStatus = customer.getStatus();
            if(newBalance<=50){
                OnMemoryDataBase.changeCustomerStatus(request.getCustomerId(), "Active");
                newStatus = "Active";
            }
            
            //Envio de la confirmación de pago por Email.
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            
            parameters.Add("$name", customer.getName());
            parameters.Add("$ammount", request.getAmmount()+"");
            parameters.Add("$newBalance", newBalance+"");
            string number = request.getCardNumber();
            string subfix = number.Substring(number.Length-4, 4);
            parameters.Add("$cardNumber", subfix);
            parameters.Add("$reference", payReference);
            parameters.Add("$newStatus", newStatus);
            emailSenderSystem.sendEmail(parameters);
            
            return new PaymentResponse(payReference, newBalance, newStatus);
            
        }
    }
}


