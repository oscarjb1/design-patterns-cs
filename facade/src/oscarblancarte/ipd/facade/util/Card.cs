/**
 * @author Oscar Javier Blancarte Iturralde.
 * @see http://oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.facade.util{
    public class Card {
        private string prefix;
        private string company;
        private string cardType;//{Credit|Debit}

        public Card(string prefix, string company, string cardType) {
            this.prefix = prefix;
            this.company = company;
            this.cardType = cardType;
        }

        public string getPrefix() {
            return prefix;
        }

        public void setPrefix(string prefix) {
            this.prefix = prefix;
        }

        public string getCompany() {
            return company;
        }

        public void setCompany(string company) {
            this.company = company;
        }

        public string getCardType() {
            return cardType;
        }

        public void setCardType(string cardType) {
            this.cardType = cardType;
        }
        
        
    }
}


