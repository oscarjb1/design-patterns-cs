using oscarblancarte.ipd.adapter.creditapi.bankx;

namespace oscarblancarte.ipd.adapter.impl{



    /**
    * @author Oscar Javier Blancarte Iturralde
    * @see http://wwww.oscarblancarteblog.com
    */
    public class XBankCreditAdapter : IBankAdapter{

        public BankCreditResponse sendCreditRequest(BankCreditRequest request) {
            
            XBankCreditRequest xrequest = new XBankCreditRequest();
            xrequest.setCustomerName(request.getCustomer());
            xrequest.setRequestAmount(request.getAmount());
            
            XBankCreditAPI api = new XBankCreditAPI();
            XBankCreditResponse xresponse = api.SendCreditRequest(xrequest);
            
            BankCreditResponse response = new BankCreditResponse();
            response.setApproved(xresponse.isAproval());
            return response;
        }
    }
}
