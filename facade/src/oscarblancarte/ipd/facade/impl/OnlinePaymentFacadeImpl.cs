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

        private static readonly CRMSystem CrmSystem = new CRMSystem();
        private static readonly BillingSystem BillingSyste = new BillingSystem();
        private static readonly BankSystem BankSyste = new BankSystem();
        private static readonly EmailSystem EmailSenderSystem = new EmailSystem();
        
        
        public PaymentResponse Pay(PaymentRequest request)  {
            Customer customer = CrmSystem.FindCustomer(request.CustomerId);
            //Validate Set
            if(customer==null){
                throw new GeneralPaymentError("Customer ID does not exist '" +request.CustomerId+"' not exist.");
            }else if("Inactive".Equals(customer.Status) ){
                throw new GeneralPaymentError("Customer ID does not exist '" +request.CustomerId+"' is inactive.");
            }else if(request.Ammount > BillingSyste.QueryCustomerBalance(customer.Id )){
                throw new GeneralPaymentError("You are trying to make a payment " + "\n\tgreater than the customer's balance");
            }
            
            //charge to the card
            TransferRequest transfer = new TransferRequest(
                    request.Ammount,request.CardNumber, 
                    request.CardName, request.CardExpDate, 
                    request.CardNumber);
            string payReference = BankSyste.Transfer(transfer);
            
            //Impact of the balance in the billing system
            BillingPayRequest billingRequest = new BillingPayRequest(
                    request.CustomerId, request.Ammount);
            double newBalance = BillingSyste.Pay(billingRequest);
            
            //The client is reactivated if the new balance is less than $ 51
            string newStatus = customer.Status;
            if(newBalance<=50){
                OnMemoryDataBase.changeCustomerStatus(request.CustomerId, "Active");
                newStatus = "Active";
            }
            
            //Envio de la confirmación de pago por Email.
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            
            parameters.Add("$name", customer.Name);
            parameters.Add("$ammount", request.Ammount+"");
            parameters.Add("$newBalance", newBalance+"");
            string number = request.CardNumber;
            string subfix = number.Substring(number.Length-4, 4);
            parameters.Add("$cardNumber", subfix);
            parameters.Add("$reference", payReference);
            parameters.Add("$newStatus", newStatus);
            EmailSenderSystem.SendEmail(parameters);
            
            return new PaymentResponse(payReference, newBalance, newStatus);
            
        }
    }
}


