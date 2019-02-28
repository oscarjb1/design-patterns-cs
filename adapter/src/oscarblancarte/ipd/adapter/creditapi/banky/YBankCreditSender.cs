using System;
using System.Threading;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://wwww.oscarblancarteblog.com
 */

namespace oscarblancarte.ipd.adapter.creditapi.banky{
    public class YBankCreditSender {

        YBankCreditApprove request;
        YBankCreditSenderListener listener;

        public void StartThread(){
            Console.WriteLine("yBank received your request in a moment you will have the answer, be patient please");
            YBankCreditApproveResult response = new YBankCreditApproveResult();
            if (request.Credit <= 1500) {
                response.Approved = "Y";
            } else {
                response.Approved = "N";
            }
            try {
                Thread.Sleep(1000 * 30);
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }

            listener.notifyCreditResult(response);
        }



        public void sendCreditForValidate(YBankCreditApprove request, YBankCreditSenderListener listener) {
            this.request = request;
            this.listener = listener;

            Thread thread = new Thread(StartThread);
            thread.Start();
        }
    }
}