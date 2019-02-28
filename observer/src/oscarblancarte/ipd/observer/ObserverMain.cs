using oscarblancarte.ipd.observer.impl.observers;
using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.observer{
    public class ObserverMain {

        static void Main(string[] args) {
            ConfigurationManager conf = ConfigurationManager.GetInstance();
            
            //Se establecen los valores por default.
            conf.setDefaultDateFormat("yyyy/MM/dd");
            conf.SetMoneyFormat("##.00");
            Console.WriteLine("Established configuration");
            
            //Se dan de alta lo observers
            DateFormatObserver dateFormatObserver = new DateFormatObserver();
            MoneyFormatObserver moneyFormatObserver = new MoneyFormatObserver();
            conf.AddObserver(dateFormatObserver);
            conf.AddObserver(moneyFormatObserver);
            Console.WriteLine("");
            
            //Se cambia la fonfiguratión
            conf.setDefaultDateFormat("dd/MM/yyyy");
            conf.SetMoneyFormat("###,#00.00");
            Console.WriteLine("");
            
            //Se realiza otro cambio en la configuración.
            conf.setDefaultDateFormat("MM/yyyy/dd");
            conf.SetMoneyFormat("###,#00");
            
            conf.RemoveObserver(dateFormatObserver);
            conf.RemoveObserver(moneyFormatObserver);
            Console.WriteLine("");
            
            //Se realiza otro cambio en la configuración.
            conf.setDefaultDateFormat("MM/yyyy");
            conf.SetMoneyFormat("###,##0.00");
        }
    }
}




