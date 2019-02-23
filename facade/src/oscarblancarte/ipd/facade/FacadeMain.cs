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
            request.setAmmount(500);
            request.setCardExpDate("10/2015");
            request.setCardName("Oscar Blancarte");
            request.setCardNumber("1234567890123456");
            request.setCardSecureNum("345");
            request.setCustomerId(1L);

            try {
                IPaymentFacade paymentFacade = new OnlinePaymentFacadeImpl();
                paymentFacade.pay(request);
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
    }
}


