/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://wwww.oscarblancarteblog.com
 */

namespace oscarblancarte.ipd.adapter.creditapi.banky{
    public interface YBankCreditSenderListener {
        void notifyCreditResult(YBankCreditApproveResult result);
    }
}