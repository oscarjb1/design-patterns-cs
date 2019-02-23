using System;

/**
 * @author Oscar Javier Blancarte Iturralde.
 * @see http://oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.facade.impl{
    public class PaymentRequest {

        private Int64 customerId;
        private double ammount;
        private string cardNumber;
        private string cardName;
        private string cardExpDate;
        private string cardSecureNum;

        public PaymentRequest() {
        }

        public Int64 getCustomerId() {
            return customerId;
        }

        public void setCustomerId(Int64 customerId) {
            this.customerId = customerId;
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


