
using oscarblancarte.ipd.strategy.impl;
using oscarblancarte.ipd.strategy.util;
using System;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Data;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.strategy.impl.providers{
    public class SQLAuthenticationProvider : IAuthenticationStrategy{
        private static readonly string USER_QUERY = "SELECT userName,rol from users where userName='{0}' and password = '{1}'";
        private MySQLDBAdapter mysqlAdapter;
        
        public SQLAuthenticationProvider(){
            mysqlAdapter = new MySQLDBAdapter();
        }
        
        public Principal authenticate(string user, string passwrd) {
            try {
                string queryUser = string.Format(USER_QUERY, user,passwrd);

                DbConnection connection = mysqlAdapter.getConnection();
                DbCommand statement = connection.CreateCommand();
                statement.CommandText = queryUser;
                statement.CommandType = CommandType.Text;
                DbDataReader query = statement.ExecuteReader();

                Principal principal = null;
                Console.WriteLine(query.HasRows);
                while(query.Read()){
                    principal = new Principal((string)query["userName"], (string)query["rol"]);
                }
                query.Close();
                connection.Close();
                return principal;
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                return null;
            }
            
        }
    }
}


