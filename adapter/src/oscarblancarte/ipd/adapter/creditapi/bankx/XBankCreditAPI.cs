using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://wwww.oscarblancarteblog.com
 */

namespace oscarblancarte.ipd.adapter.creditapi.bankx{
    public class XBankCreditAPI {
        
        public XBankCreditResponse SendCreditRequest(XBankCreditRequest request){
            XBankCreditResponse response =new XBankCreditResponse();
            if(request.getRequestAmount()<= 5000){
                response.setAproval(true);
            }else{
                response.setAproval(false);
            }
            return response;
        }
    }
} 