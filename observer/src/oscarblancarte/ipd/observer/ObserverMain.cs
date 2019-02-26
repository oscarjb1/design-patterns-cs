using oscarblancarte.ipd.observer.impl.observers;
using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.observer{
    public class ObserverMain {

        static void Main(string[] args) {
            ConfigurationManager conf = ConfigurationManager.getInstance();
            
            //Se establecen los valores por default.
            conf.setDefaultDateFormat("yyyy/MM/dd");
            conf.setMoneyFormat("##.00");
            Console.WriteLine("Established configuration");
            
            //Se dan de alta lo observers
            DateFormatObserver dateFormatObserver = new DateFormatObserver();
            MoneyFormatObserver moneyFormatObserver = new MoneyFormatObserver();
            conf.addObserver(dateFormatObserver);
            conf.addObserver(moneyFormatObserver);
            Console.WriteLine("");
            
            //Se cambia la fonfiguratión
            conf.setDefaultDateFormat("dd/MM/yyyy");
            conf.setMoneyFormat("###,#00.00");
            Console.WriteLine("");
            
            //Se realiza otro cambio en la configuración.
            conf.setDefaultDateFormat("MM/yyyy/dd");
            conf.setMoneyFormat("###,#00");
            
            conf.removeObserver(dateFormatObserver);
            conf.removeObserver(moneyFormatObserver);
            Console.WriteLine("");
            
            //Se realiza otro cambio en la configuración.
            conf.setDefaultDateFormat("MM/yyyy");
            conf.setMoneyFormat("###,##0.00");
        }
    }
}




