using oscarblancarte.ipd.factorymethod.impl;
using oscarblancarte.ipd.factorymethod.util;
using System;
using System.Collections.Generic;

namespace oscarblancarte.ipd.factorymethod{
    public class DBFactory {

        private static readonly string DB_FACTORY_PROPERTY_URL = "./DBFactory.properties";
        private static readonly string DEFAULT_DB_CLASS_PROP = "defaultDBClass";

        public static IDBAdapter GetDBadapter(DBType dbType) {
            switch (dbType) {
                case DBType.MySQL:
                    return new MySQLDBAdapter();
                case DBType.Oracle:
                    return new OracleDBAdapter();
                default:
                    throw new SystemException("Not supported");
            }
        }

        public static IDBAdapter GetDefaultDBAdapter() {
            try {
                IDictionary<string,string> prop = PropertiesUtil.LoadProperty(DB_FACTORY_PROPERTY_URL);
                String defaultDBClass = prop[DEFAULT_DB_CLASS_PROP];
                Console.WriteLine("DefaultDBClass ==> " + defaultDBClass);
                Type type = Type.GetType(defaultDBClass);
                return (IDBAdapter) Activator.CreateInstance(type);
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}



