/**
 * @author Oscar Javier Blancarte Iturralde.
 * @see http://oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.strategy.util{
    public class User {

        private string userName;
        private string password;
        private string rol;

        public User(string userName, string password, string rol) {
            this.userName = userName;
            this.password = password;
            this.rol = rol;
        }

        public string getUserName() {
            return userName;
        }

        public void setUserName(string userName) {
            this.userName = userName;
        }

        public string getPassword() {
            return password;
        }

        public void setPassword(string password) {
            this.password = password;
        }

        public string getRol() {
            return rol;
        }

        public void setRol(string rol) {
            this.rol = rol;
        }

    }
}


