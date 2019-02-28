using System;

namespace oscarblancarte.ipd.singleton{
    public class SingletonMain {

        static void Main(string[] args) {
            //Modul 1
            ConfigurationSingleton singletonA = ConfigurationSingleton.GetInstance();
            //Modul 2
            ConfigurationSingleton singletonB = ConfigurationSingleton.GetInstance();
            
            Console.WriteLine(singletonA);
            Console.WriteLine(singletonB);
            Console.WriteLine("Same reference ==> " + (singletonA == singletonB));
            
            singletonA.AppName = "Singleton Pattern";
            singletonB.AppVersion = "1.0x";
            
            Console.WriteLine("SingletonA ==> " + singletonA);
            Console.WriteLine("SingletonB ==> " + singletonB);
            
            singletonA = null;
            singletonB = null;
            
            singletonA = ConfigurationSingleton.GetInstance();
            Console.WriteLine("singletonA ==> " + singletonA);
        }
    }
}

