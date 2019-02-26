using oscarblancarte.ipd.strategy.impl;
using oscarblancarte.ipd.strategy.impl.providers;
using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.strategy{
    public class StrategyMain {

        private static AuthenticationProvider authProvider = new AuthenticationProvider();

        static void Main(string[] args) {
            changeAuthetificationStrategy();
            Principal principal = null;
            do {
                Console.WriteLine("\n\nPlease authenticate:");
                Console.WriteLine("User:");
                string userName = Console.ReadLine();
                Console.WriteLine("Pasword:");
                string password = Console.ReadLine();

                principal = authProvider.authenticate(userName, password);
                if (principal == null) {
                    Console.WriteLine("User or password invalid.");
                    Console.WriteLine("Do you want to change the authentication method? (S/N)");

                    string op = Console.ReadLine();

                    if (string.Equals(op, "S", StringComparison.OrdinalIgnoreCase)) {
                        changeAuthetificationStrategy();
                    }
                }
            } while (principal == null);

            Console.WriteLine("Successful authentication");
            Console.WriteLine(principal);

            Console.Read();
            
        }

        private static void changeAuthetificationStrategy() {
            Console.WriteLine("Enter the type of authentication to use.");
            Console.WriteLine("1.-OnMemory Authentication");
            Console.WriteLine("2.-SQL Authentication");
            Console.WriteLine("3.-XML Authentication");
            int op = int.Parse(Console.ReadLine());
            switch (op) {
                case 1:
                    authProvider.setAuthenticationStrategy(new OnMemoryAuthenticationProvider());
                    Console.WriteLine("OnMemory Authentication Select >");
                    break;
                case 2:
                    authProvider.setAuthenticationStrategy(new SQLAuthenticationProvider());
                    Console.WriteLine("SQL Authentication Select >");
                    break;
                case 3:
                    authProvider.setAuthenticationStrategy(new XMLAuthenticationProvider());
                    Console.WriteLine("XML Authentication Select >");
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    Environment.Exit(0);
                    break;   
            }
        }
    }
}