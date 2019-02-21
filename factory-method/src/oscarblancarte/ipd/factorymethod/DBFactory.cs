using oscarblancarte.ipd.factorymethod.impl;
using oscarblancarte.ipd.factorymethod.util;
using System;

namespace oscarblancarte.ipd.factorymethod{
    public class DBFactory {

        private static readonly string DB_FACTORY_PROPERTY_URL = "META-INF/DBFactory.properties";
        private static readonly string DEFAULT_DB_CLASS_PROP = "defaultDBClass";

        public static IDBAdapter getDBadapter(DBType dbType) {
            switch (dbType) {
                case MySQL:
                    return new MySQLDBAdapter();
                case Oracle:
                    return new OracleDBAdapter();
                default:
                    throw new IllegalArgumentException("Not supported");
            }
        }

        public static IDBAdapter getDefaultDBAdapter() {
            try {
                Properties prop = PropertiesUtil.loadProperty(DB_FACTORY_PROPERTY_URL);
                String defaultDBClass = prop.getProperty(DEFAULT_DB_CLASS_PROP);
                Console.WriteLine("DefaultDBClass ==> " + defaultDBClass);
                return (IDBAdapter) Class.forName(defaultDBClass).newInstance();
            } catch (Exception e) {
                e.printStackTrace();
                return null;
            }
        }
    }
}



