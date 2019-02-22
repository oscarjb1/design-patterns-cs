/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://wwww.oscarblancarteblog.com
 */

namespace oscarblancarte.ipd.adapter.impl{

    public class BankCreditResponse {
        public bool approved;

        public bool isApproved() {
            return approved;
        }

        public void setApproved(bool approved) {
            this.approved = approved;
        }
    }
}

