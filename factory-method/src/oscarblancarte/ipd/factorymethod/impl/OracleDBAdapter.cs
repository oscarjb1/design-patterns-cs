using oscarblancarte.ipd.factorymethod;
using oscarblancarte.ipd.factorymethod.util;
using System;
using System.Data;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client; 
using System.Collections.Generic;
using System.IO;
using Authlete.Util;

namespace oscarblancarte.ipd.factorymethod.impl{
    public class OracleDBAdapter : IDBAdapter {

        private static readonly string DB_PROPERTIES = "./DBOracle.properties";

        private static readonly string DB_SERVICE_PROP = "service";
        private static readonly string DB_HOST_PROP = "host";
        private static readonly string DB_PASSWORD_PROP = "password";
        private static readonly string DB_PORT_PROP = "port";
        private static readonly string DB_USER_PROP = "user";


        public IDbConnection GetConnection() {
            try {
                String connectionString = CreateConnectionString();
                IDbConnection connection = new OracleConnection(connectionString);
                connection.Open();
                Console.WriteLine("Connection class ==> " + connection.GetType().Name );
                return connection;
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                return null;
            }
            
        }

        public string CreateConnectionString() {
            IDictionary<string, string> prop = null;
            using (TextReader reader = new StreamReader(DB_PROPERTIES))
            {
                prop = PropertiesLoader.Load(reader);
            }

            string host = prop[DB_HOST_PROP];
            string port = prop[DB_PORT_PROP];
            string service = prop[DB_SERVICE_PROP];
            string user = prop[DB_USER_PROP];
            string password = prop[DB_PASSWORD_PROP];

            // string connectionString = "jdbc:oracle:thin:"+user+"/"+password+"@//"+host+":"+port+"/"+service;
            
            string connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + host+ ")(PORT=" + port + ")))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + service + ")));User Id=" + user + ";Password=" + password + ";Enlist=false;Pooling=true";
            Console.WriteLine("ConnectionString ==> " + connectionString);
            return connectionString;
        }
    }
}