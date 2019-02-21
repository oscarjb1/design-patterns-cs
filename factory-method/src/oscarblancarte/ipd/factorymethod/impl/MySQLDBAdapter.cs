using oscarblancarte.ipd.factorymethod;
using oscarblancarte.ipd.factorymethod.util;
using System;
using System.Data;
using System.Data.SqlClient;
using Oracle.DataAccess.Client; 

namespace oscarblancarte.ipd.factorymethod.impl{
    public class MySQLDBAdapter : IDBAdapter {

        private static readonly string DB_PROPERTIES = "META-INF/DBMySQL.properties";

        //Propiedades de los archivos properties
        private static readonly string DB_NAME_PROP = "dbname";
        private static readonly string DB_HOST_PROP = "host";
        private static readonly string DB_PASSWORD_PROP = "password";
        private static readonly string DB_PORT_PROP = "port";
        private static readonly string DB_USER_PROP = "user";

        static {
            //Bloque para registrar el Driver de MySQL
            try {
                new com.mysql.jdbc.Driver();
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        public IDbConnection getConnection() {
            try {
                String connectionString = createConnectionString();
                Connection connection = DriverManager.getConnection(connectionString);
                Console.WriteLine("Connection class ==> " + typeof(Connection).Name );
                return connection;
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                return null;
            }

        }

        private String createConnectionString() {
            Properties prop = PropertiesUtil.loadProperty(DB_PROPERTIES);
            String host = prop.getProperty(DB_HOST_PROP);
            String port = prop.getProperty(DB_PORT_PROP);
            String db = prop.getProperty(DB_NAME_PROP);
            String user = prop.getProperty(DB_USER_PROP);
            String password = prop.getProperty(DB_PASSWORD_PROP);

            String connectionString = "jdbc:mysql://" + host + ":" + port + "/" + db + "?user=" + user + "&password=" + password;
            Console.WriteLine("ConnectionString ==> " + connectionString);
            return connectionString;
        }
    }
}


