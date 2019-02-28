
using oscarblancarte.ipd.observer.impl;
using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.observer.impl.observers{
    public class MoneyFormatObserver : IObserver{
        public void NotifyObserver(string command, Object source) {
            if(command.Equals("moneyFormat")){
                ConfigurationManager conf = (ConfigurationManager)source;
                Console.WriteLine("Observer ==> MoneyFormatObserver.moneyFormatChange > " + 1.11.ToString(conf.GetMoneyFormat()) );
            }
        }
    }
}


