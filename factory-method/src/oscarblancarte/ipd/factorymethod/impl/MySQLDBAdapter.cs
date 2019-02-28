using oscarblancarte.ipd.factorymethod;
using oscarblancarte.ipd.factorymethod.util;
using System;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.IO;
using System.Collections.Generic;
using Authlete.Util;

namespace oscarblancarte.ipd.factorymethod.impl{
    public class MySQLDBAdapter : IDBAdapter {

        private static readonly string DB_PROPERTIES = "./DBMySQL.properties";

        //Propiedades de los archivos properties
        private static readonly string DB_NAME_PROP = "dbname";
        private static readonly string DB_HOST_PROP = "host";
        private static readonly string DB_PASSWORD_PROP = "password";
        private static readonly string DB_PORT_PROP = "port";
        private static readonly string DB_USER_PROP = "user";

        public IDbConnection GetConnection() {
            try {
                String connectionString = CreateConnectionString();
                DbConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Connection class ==> " + connection.GetType().Name );
                return connection;
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                return null;
            }

        }

        private String CreateConnectionString() {
            IDictionary<string, string> prop = null;
            using (TextReader reader = new StreamReader(DB_PROPERTIES))
            {
                prop = PropertiesLoader.Load(reader);
            }
            //Properties prop = PropertiesUtil.loadProperty(DB_PROPERTIES);
            String host = prop[DB_HOST_PROP];
            String port = prop[DB_PORT_PROP];
            String db = prop[DB_NAME_PROP];
            String user = prop[DB_USER_PROP];
            String password = prop[DB_PASSWORD_PROP];

            string connectionString = "SERVER=" + host + ";" + "DATABASE=" + db + ";" + "UID=" + user + ";" + "PASSWORD=" + password + ";";
            Console.WriteLine("ConnectionString ==> " + connectionString);
            return connectionString;
        }
    }
}


