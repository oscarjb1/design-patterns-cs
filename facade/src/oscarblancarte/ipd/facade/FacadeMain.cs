using oscarblancarte.ipd.facade.impl;
using System;

/**
 * @author Oscar Javier Blancarte Iturralde.
 * @see http://oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.facade{
    public class FacadeMain {

        static void Main(string[] args) {


            string a  = "1234567890";
            Console.WriteLine(a.Substring(a.Length-4,4));
            //number.Length-4, number.Length

            PaymentRequest request = new PaymentRequest();
            request.Ammount = 500;
            request.CardExpDate = "10/2015";
            request.CardName = "Oscar Blancarte";
            request.CardNumber = "1234567890123456";
            request.CardSecureNum = "345";
            request.CustomerId = 1L;

            try {
                IPaymentFacade paymentFacade = new OnlinePaymentFacadeImpl();
                paymentFacade.Pay(request);
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
    }
}


