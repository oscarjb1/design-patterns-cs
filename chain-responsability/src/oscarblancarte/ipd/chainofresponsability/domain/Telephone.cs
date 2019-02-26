/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.chainofresponsability.domain{
    public class Telephone {

        private string lada;
        private string number;
        private string ext;

        public string getLada() {
            return lada;
        }

        public void setLada(string lada) {
            this.lada = lada;
        }

        public string getNumber() {
            return number;
        }

        public void setNumber(string number) {
            this.number = number;
        }

        public string getExt() {
            return ext;
        }

        public void setExt(string ext) {
            this.ext = ext;
        }

    }

}


