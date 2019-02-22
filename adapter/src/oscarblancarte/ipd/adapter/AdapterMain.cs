using oscarblancarte.ipd.adapter.impl;
using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://wwww.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.adapter{
    public class AdapterMain {

        static void Main(string[] args) {
            //Generic request for the two API's
            BankCreditRequest request = new BankCreditRequest();
            request.setCustomer("Oscar Blancarte");
            request.setAmount(1000);

            IBankAdapter xBank = new XBankCreditAdapter();
            BankCreditResponse xresponse = xBank.sendCreditRequest(request);
            Console.WriteLine("xBank approved > " + xresponse.isApproved() + "\n");

            IBankAdapter yBank = new YBankCreditAdapter();
            BankCreditResponse yresponse = yBank.sendCreditRequest(request);
            Console.WriteLine("yBank approved > " + yresponse.isApproved() + "\n");

            if (xresponse.isApproved()) {
                Console.WriteLine("xBank approved your credit, congratulations!!");
            } else if (yresponse.isApproved()) {
                Console.WriteLine("yBank approved your credit, congratulations!!");
            } else {
                Console.WriteLine("Sorry your credit has not been approved");
            }
        }
    }
}




