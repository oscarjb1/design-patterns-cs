/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://wwww.oscarblancarteblog.com
 */

namespace oscarblancarte.ipd.adapter.creditapi.banky{
    public class YBankCreditApprove {
        public string name;
        public float credit;

        public string getName() {
            return name;
        }

        public void setName(string name) {
            this.name = name;
        }

        public float getCredit() {
            return credit;
        }

        public void setCredit(float credit) {
            this.credit = credit;
        }   
    }
}


