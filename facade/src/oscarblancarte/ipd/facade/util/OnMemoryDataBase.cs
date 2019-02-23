using System;
using System.Collections.Generic;
/**
 * @author Oscar Javier Blancarte Iturralde.
 * @see http://oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.facade.util{
    public class OnMemoryDataBase {

        private static readonly Dictionary<Int64, Customer> CUSTOMER_MAP = new Dictionary<Int64, Customer>();
        private static readonly Dictionary<String, Card> CARD_BINS = new Dictionary<String, Card>();

        static OnMemoryDataBase(){
            CUSTOMER_MAP.Add(1L, new Customer(1L, "Oscar Blancarte", 500, "Discontinued"));
            CUSTOMER_MAP.Add(2L, new Customer(2L, "Juan Perez", 300, "Discontinued"));
            CUSTOMER_MAP.Add(3L, new Customer(3L, "Adrian Lopez", 100, "Active"));
            CUSTOMER_MAP.Add(4L, new Customer(4L, "Melisa Mares", 100, "Inactive"));

            CARD_BINS.Add("123", new Card("123", "VISA", "Credit"));
            CARD_BINS.Add("234", new Card("234", "MASTERCARD", "Debit"));
            CARD_BINS.Add("345", new Card("345", "AMEX", "Credit"));
        }

        public static Customer findCustomerById(Int64 id) {
            return CUSTOMER_MAP[id];
        }

        public static void changeCustomerStatus(Int64 id, string newStatus) {
            Customer customer = findCustomerById(id);
            customer.setStatus(newStatus);
            Console.WriteLine("Change of client status '" + customer.getName()
                    + "'" + newStatus);
        }

        public static bool validateCardBins(string creditCardPrefix) {
            if (CARD_BINS.ContainsKey(creditCardPrefix)) {
                string company = CARD_BINS[creditCardPrefix].getCompany();
                Console.WriteLine("Valid card > '" + creditCardPrefix + "', "
                        + company + "\n");
                return true;
            } else {
                Console.WriteLine("Invalid card >\n");
                return false;
            }
        }

        public static string getCardCompany(string creditCardPrefix) {
            if (CARD_BINS.ContainsKey(creditCardPrefix)) {
                return CARD_BINS[creditCardPrefix].getCompany();
            }
            throw new SystemException("Card does not exist");
        }
    }
}



