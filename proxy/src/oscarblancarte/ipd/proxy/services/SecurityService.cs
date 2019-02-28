using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */

namespace oscarblancarte.ipd.proxy.services{
    public class SecurityService {
        public bool Authorization(string user,string password){
            if(user.Equals("oblancarte") && password.Equals("1234")){
                Console.WriteLine("User " + user + " authorized");
                return true;
            }else{
                Console.WriteLine("User " + user + " no authorized");
                return false;
            }
        }
    }
}


