using oscarblancarte.ipd.adapter.creditapi.banky;
using System;
using System.Threading;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://wwww.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.adapter.impl{

    public class YBankCreditAdapter : IBankAdapter, YBankCreditSenderListener {

        private YBankCreditApproveResult yresponse;

        public BankCreditResponse sendCreditRequest(BankCreditRequest request) {
            YBankCreditApprove yrequest = new YBankCreditApprove();
            yrequest.setCredit((float) request.getAmount());
            yrequest.setName(request.getCustomer());

            YBankCreditSender sender = new YBankCreditSender();
            sender.sendCreditForValidate(yrequest, this);

            do {
                try {
                    Thread.Sleep(10000);
                    Console.WriteLine("yBank request on hold....");
                } catch (Exception e) {
                    Console.WriteLine(e.ToString());
                }
            } while (yresponse == null);

            BankCreditResponse response = new BankCreditResponse();
            response.setApproved(yresponse.getApproved() == "Y" ? true : false);
            return response;
        }

        public void notifyCreditResult(YBankCreditApproveResult result) {
            this.yresponse = result;
        }
    }
}



