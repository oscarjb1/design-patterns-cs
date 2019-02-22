/**
 * @author oscar javier blancarte iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.prototype.impl{
    public class ProductItem : IPrototype {
        private string name;
        private double price;
        
        public ProductItem(){
        }

        public ProductItem(string name, double price) {
            this.name = name;
            this.price = price;
        }

        public string getName() {
            return name;
        }

        public void setName(string name) {
            this.name = name;
        }

        public double getPrice() {
            return price;
        }

        public void setPrice(double price) {
            this.price = price;
        }

        public IPrototype clone() {
            return new ProductItem(this.name,this.price);
        }

        public IPrototype deepClone() {
            return clone();
        }

        public override string ToString() {
            return "ProductItem{" + "name=" + name + ", price=" + price + '}';
        }
    }
}


