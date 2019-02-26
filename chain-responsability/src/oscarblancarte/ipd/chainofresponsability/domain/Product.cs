/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.chainofresponsability.domain{
    public class Product {
        private string name;
        private double listPrice;

        public string getName() {
            return name;
        }

        public void setName(string name) {
            this.name = name;
        }

        public double getListPrice() {
            return listPrice;
        }

        public void setListPrice(double listPrice) {
            this.listPrice = listPrice;
        }
    }
}


