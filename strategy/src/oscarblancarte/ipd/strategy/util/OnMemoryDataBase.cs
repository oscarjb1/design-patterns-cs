using System.Collections.Generic;

/**
 * @author Oscar Javier Blancarte Iturralde.
 * @see http://oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.strategy.util{
    public class OnMemoryDataBase {

        private static readonly Dictionary<string, User> USER_MAP = new Dictionary<string, User>();

        static OnMemoryDataBase (){
            USER_MAP.Add("oblancarte",new User("oblancarte", "1234", "Admin"));
            USER_MAP.Add("rlopez",new User("rlopez", "2345", "Cajero"));
            USER_MAP.Add("lcastro",new User("lcastro", "2345", "Supervisor"));
        }

        public static User findUserByName(string name){
            if(USER_MAP.ContainsKey(name)){
                return USER_MAP[name];
            }
            return null;
            
        }
    }
}




