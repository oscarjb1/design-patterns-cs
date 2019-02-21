using System;

namespace oscarblancarte.ipd.singleton{
    public class SingletonMain {

        static void Main(string[] args) {
            //Modul 1
            ConfigurationSingleton singletonA = ConfigurationSingleton.getInstance();
            //Modul 2
            ConfigurationSingleton singletonB = ConfigurationSingleton.getInstance();
            
            Console.WriteLine(singletonA);
            Console.WriteLine(singletonB);
            Console.WriteLine("Same reference ==> " + (singletonA == singletonB));
            
            singletonA.setAppName("Singleton Pattern");
            singletonB.setAppVersion("1.0x");
            
            Console.WriteLine("SingletonA ==> " + singletonA);
            Console.WriteLine("SingletonB ==> " + singletonB);
            
            singletonA = null;
            singletonB = null;
            
            singletonA = ConfigurationSingleton.getInstance();
            Console.WriteLine("singletonA ==> " + singletonA);
        }
    }
}

