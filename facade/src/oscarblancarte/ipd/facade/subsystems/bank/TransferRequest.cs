/**
 * @author Oscar Javier Blancarte Iturralde.
 * @see http://oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.facade.subsystems.bank{
    public class TransferRequest {

        public double Ammount{get; set;}
        public string CardNumber{get; set;}
        public string CardName{get; set;}
        public string CardExpDate{get; set;}
        public string CardSecureNum{get; set;}

        public TransferRequest(double ammount, string cardNumber, string cardName, string cardExpDate, string cardSecureNum) {
            this.Ammount = ammount;
            this.CardNumber = cardNumber;
            this.CardName = cardName;
            this.CardExpDate = cardExpDate;
            this.CardSecureNum = cardSecureNum;
        }
    }
}