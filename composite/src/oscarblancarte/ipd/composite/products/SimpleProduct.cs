/**
 * @author oblancarte
 */
namespace oscarblancarte.ipd.composite.products{
    public class SimpleProduct : AbstractProduct {

        protected string brand;

        public SimpleProduct(string name, double price, string brand): base(name, price) {
            
            this.brand = brand;
        }

        public string getBrand() {
            return brand;
        }

        public void setBrand(string brand) {
            this.brand = brand;
        }
    }
}


