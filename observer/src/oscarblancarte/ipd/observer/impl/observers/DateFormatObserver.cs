using oscarblancarte.ipd.observer.impl;
using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.observer.impl.observers{
    public class DateFormatObserver : IObserver{

        public void notifyObserver(string command, Object source) {
            if(command.Equals("defaultDateFormat")){
                ConfigurationManager conf = (ConfigurationManager)source;
                Console.WriteLine("Observer ==> DateFormatObserver.dateFormatChange > " + DateTime.Now.ToString(conf.getDefaultDateFormat()) );
            }
        }   
    }
}


