using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace oscarblancarte.ipd.strategy.util{
    public class MySQLDBAdapter  {

        private static readonly string DB_PROPERTIES = "META-INF/DBMySQL.properties";

        //Propiedades de los archivos properties
        private static readonly string DB_NAME_PROP = "dbname";
        private static readonly string DB_HOST_PROP = "host";
        private static readonly string DB_PASSWORD_PROP = "password";
        private static readonly string DB_PORT_PROP = "port";
        private static readonly string DB_USER_PROP = "user";

        public DbConnection getConnection() {
            try {
                string connectionString = createConnectionString();
                DbConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Connection class ==> " + typeof(MySqlConnection).Name);
                return connection;
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        private string createConnectionString() {
            NameValueCollection props = PropertiesUtil.loadProperty();
            //string factoryClass = ConfigurationManager.AppSettings["serviceProductImplClass"].ToString();
            string host = props[DB_HOST_PROP];
            string port = props[DB_PORT_PROP];
            string db = props[DB_NAME_PROP];
            string user = props[DB_USER_PROP];
            string password = props[DB_PASSWORD_PROP];

            //string connectionString = "jdbc:mysql://" + host + ":" + port + "/" + db + "?user=" + user + "&password=" + password;
            string connectionString = "SERVER=" + host + ";" + "DATABASE=" + db + ";" + "UID=" + user + ";" + "PASSWORD=" + password + ";";
            Console.WriteLine("ConnectionString ==> " + connectionString);
            return connectionString;
        }
    }
}



