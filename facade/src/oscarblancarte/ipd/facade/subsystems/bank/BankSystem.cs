using System;
using oscarblancarte.ipd.facade.impl;
using oscarblancarte.ipd.facade.util;

/**
 * @author Oscar Javier Blancarte Iturralde.
 * @see http://oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.facade.subsystems.bank{
    public class BankSystem {

        public string Transfer(TransferRequest request)  {
            string cardNumerPrefix = request.CardNumber.Substring(0, 3);
            if (!OnMemoryDataBase.validateCardBins(cardNumerPrefix)) {
                throw new GeneralPaymentError("Invalid card.");
            }
            string cardCompany = OnMemoryDataBase.getCardCompany(cardNumerPrefix);
            if ("AMEX".Equals(cardCompany) && request.CardNumber.Length != 15) {
                throw new GeneralPaymentError("Invalid card number");
            } else if (("VISA".Equals(cardCompany) || "MASTERCARD".Equals(cardCompany)) && request.CardNumber.Length != 16) {
                throw new GeneralPaymentError("Invalid card number");
            }
            string number = request.CardNumber;
            Console.WriteLine("number.Length => " + number.Length);
            string cardNumerSubfix = number.Substring(number.Length-4, 4);
            Console.WriteLine("A charge has been made to the client '"
                    + request.CardName + "' \n"
                    + "\tFor the amount of '" + request.Ammount + "' to the card "
                    + "termination '"+cardNumerSubfix+"'.\n");
            
            return System.Guid.NewGuid().ToString();
        }
    }
}


