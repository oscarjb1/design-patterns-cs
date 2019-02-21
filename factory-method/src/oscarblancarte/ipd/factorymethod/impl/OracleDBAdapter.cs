using java.sql.Connection;
using java.sql.DriverManager;
using java.sql.Statement;
using java.util.Properties;
using oracle.jdbc.OracleDriver;
using oscarblancarte.ipd.factorymethod;
using oscarblancarte.ipd.factorymethod.util;
using System;
using System.Data;
using System.Data.SqlClient;
using Oracle.DataAccess.Client; 


namespace oscarblancarte.ipd.factorymethod.impl{
    public class OracleDBAdapter : IDBAdapter {

        private static readonly string DB_PROPERTIES = "META-INF/DBOracle.properties";

        private static readonly string DB_SERVICE_PROP = "service";
        private static readonly string DB_HOST_PROP = "host";
        private static readonly string DB_PASSWORD_PROP = "password";
        private static readonly string DB_PORT_PROP = "port";
        private static readonly string DB_USER_PROP = "user";


        public IDbConnection getConnection() {
            try {

                string connectionString = this.createConnectionString();
                OracleConnection con = new OracleConnection(); 
                con.ConnectionString = connectionString; 
                con.Open(); 
                //Connection connection = DriverManager.getConnection(connectionString);
                SqlConnection connection = new SqlConnection(connectionString);
                Console.WriteLine("Connection class ==> " + typeof(SqlConnection).Name);
                return connection;
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                return null;
            }

            
        }

        public string createConnectionString() {
            Properties prop = PropertiesUtil.loadProperty(DB_PROPERTIES);
            string host = prop.getProperty(DB_HOST_PROP);
            string port = prop.getProperty(DB_PORT_PROP);
            string service = prop.getProperty(DB_SERVICE_PROP);
            string user = prop.getProperty(DB_USER_PROP);
            string password = prop.getProperty(DB_PASSWORD_PROP);

            // string connectionString = "jdbc:oracle:thin:"+user+"/"+password+"@//"+host+":"+port+"/"+service;
            string connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));User Id=system;Password=1234;Enlist=false;Pooling=true";
            Console.WriteLine("ConnectionString ==> " + connectionString);
            return connectionString;
        }
    }
}