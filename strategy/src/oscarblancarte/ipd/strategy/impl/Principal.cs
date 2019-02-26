/**
 * @author Oscar Javier Blancarte Iturralde.
 * @see http://oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.strategy.impl{
    public class Principal {

        private string userName;
        private string rol;

        public Principal(string userName, string rol) {
            this.userName = userName;
            this.rol = rol;
        }

        public string getUserName() {
            return userName;
        }

        public void setUserName(string userName) {
            this.userName = userName;
        }

        public string getRol() {
            return rol;
        }

        public void setRol(string rol) {
            this.rol = rol;
        }

        public override string ToString() {
            return "Principal{" + "userName=" + userName + ", rol=" + rol + '}';
        }
    }
}