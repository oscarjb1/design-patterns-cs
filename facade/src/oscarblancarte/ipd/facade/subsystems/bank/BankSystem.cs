using System;
using oscarblancarte.ipd.facade.impl;
using oscarblancarte.ipd.facade.util;

/**
 * @author Oscar Javier Blancarte Iturralde.
 * @see http://oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.facade.subsystems.bank{
    public class BankSystem {

        public string transfer(TransferRequest request)  {
            string cardNumerPrefix = request.getCardNumber().Substring(0, 3);
            if (!OnMemoryDataBase.validateCardBins(cardNumerPrefix)) {
                throw new GeneralPaymentError("Invalid card.");
            }
            string cardCompany = OnMemoryDataBase.getCardCompany(cardNumerPrefix);
            if ("AMEX".Equals(cardCompany) && request.getCardNumber().Length != 15) {
                throw new GeneralPaymentError("Invalid card number");
            } else if (("VISA".Equals(cardCompany) || "MASTERCARD".Equals(cardCompany))
                    && request.getCardNumber().Length != 16) {
                throw new GeneralPaymentError("Invalid card number");
            }
            string number = request.getCardNumber();
            Console.WriteLine("number.Length => " + number.Length);
            string cardNumerSubfix = number.Substring(number.Length-4, 4);
            Console.WriteLine("A charge has been made to the client '"
                    + request.getCardName() + "' \n"
                    + "\tFor the amount of '" + request.getAmmount() + "' to the card "
                    + "termination '"+cardNumerSubfix+"'.\n");
            
            return System.Guid.NewGuid().ToString();
        }
    }
}


