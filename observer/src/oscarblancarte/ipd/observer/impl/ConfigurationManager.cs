using System;
using oscarblancarte.ipd.observer.impl;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.observer{
    public class ConfigurationManager : AbstractObservable {

        private string defaultDateFormat;
        private string moneyFormat;

        private static ConfigurationManager configurationManager;

        private ConfigurationManager() {
        }

        public static ConfigurationManager getInstance() {
            if (configurationManager == null) {
                configurationManager = new ConfigurationManager();
            }
            return configurationManager;
        }

        public string getDefaultDateFormat() {
            return defaultDateFormat;
        }

        public void setDefaultDateFormat(string defaultDateFormat) {
            this.defaultDateFormat = defaultDateFormat;
            notifyAllObservers("defaultDateFormat", this);
        }

        public string getMoneyFormat() {
            return moneyFormat;
        }

        public void setMoneyFormat(string moneyFormat) {
            this.moneyFormat = moneyFormat;
            notifyAllObservers("moneyFormat", this);
        }
    }
}



