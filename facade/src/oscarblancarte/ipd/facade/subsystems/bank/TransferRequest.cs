/**
 * @author Oscar Javier Blancarte Iturralde.
 * @see http://oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.facade.subsystems.bank{
    public class TransferRequest {

        private double ammount;
        private string cardNumber;
        private string cardName;
        private string cardExpDate;
        private string cardSecureNum;

        public TransferRequest(double ammount, string cardNumber, string cardName, string cardExpDate, string cardSecureNum) {
            this.ammount = ammount;
            this.cardNumber = cardNumber;
            this.cardName = cardName;
            this.cardExpDate = cardExpDate;
            this.cardSecureNum = cardSecureNum;
        }

        public double getAmmount() {
            return ammount;
        }

        public void setAmmount(double ammount) {
            this.ammount = ammount;
        }

        public string getCardNumber() {
            return cardNumber;
        }

        public void setCardNumber(string cardNumber) {
            this.cardNumber = cardNumber;
        }

        public string getCardName() {
            return cardName;
        }

        public void setCardName(string cardName) {
            this.cardName = cardName;
        }

        public string getCardExpDate() {
            return cardExpDate;
        }

        public void setCardExpDate(string cardExpDate) {
            this.cardExpDate = cardExpDate;
        }

        public string getCardSecureNum() {
            return cardSecureNum;
        }

        public void setCardSecureNum(string cardSecureNum) {
            this.cardSecureNum = cardSecureNum;
        }

    }
}


