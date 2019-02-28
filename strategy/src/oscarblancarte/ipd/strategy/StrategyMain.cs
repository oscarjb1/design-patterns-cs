using oscarblancarte.ipd.strategy.impl;
using oscarblancarte.ipd.strategy.impl.providers;
using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.strategy{
    public class StrategyMain {

        private static AuthenticationProvider AuthProvider = new AuthenticationProvider();

        static void Main(string[] args) {
            ChangeAuthetificationStrategy();
            Principal principal = null;
            do {
                Console.WriteLine("\n\nPlease authenticate:");
                Console.WriteLine("User:");
                string userName = Console.ReadLine();
                Console.WriteLine("Pasword:");
                string password = Console.ReadLine();

                principal = AuthProvider.Authenticate(userName, password);
                if (principal == null) {
                    Console.WriteLine("User or password invalid.");
                    Console.WriteLine("Do you want to change the authentication method? (S/N)");

                    string op = Console.ReadLine();

                    if (string.Equals(op, "S", StringComparison.OrdinalIgnoreCase)) {
                        ChangeAuthetificationStrategy();
                    }
                }
            } while (principal == null);

            Console.WriteLine("Successful authentication");
            Console.WriteLine(principal);

            Console.Read();
            
        }

        private static void ChangeAuthetificationStrategy() {
            Console.WriteLine("Enter the type of authentication to use.");
            Console.WriteLine("1.-OnMemory Authentication");
            Console.WriteLine("2.-SQL Authentication");
            Console.WriteLine("3.-XML Authentication");
            int op = int.Parse(Console.ReadLine());
            switch (op) {
                case 1:
                    AuthProvider.SetAuthenticationStrategy(new OnMemoryAuthenticationProvider());
                    Console.WriteLine("OnMemory Authentication Select >");
                    break;
                case 2:
                    AuthProvider.SetAuthenticationStrategy(new SQLAuthenticationProvider());
                    Console.WriteLine("SQL Authentication Select >");
                    break;
                case 3:
                    AuthProvider.SetAuthenticationStrategy(new XMLAuthenticationProvider());
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