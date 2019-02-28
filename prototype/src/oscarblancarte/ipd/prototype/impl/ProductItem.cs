/**
 * @author oscar javier blancarte iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.prototype.impl{
    public class ProductItem : IPrototype {
        public string Name{get; set;}
        public double Price{get; set;}
        
        public ProductItem(){
        }

        public ProductItem(string name, double price) {
            this.Name = name;
            this.Price = price;
        }

        public IPrototype Clone() {
            return new ProductItem(this.Name,this.Price);
        }

        public IPrototype DeepClone() {
            return Clone();
        }

        public override string ToString() {
            return "ProductItem{" + "name=" + Name + ", price=" + Price + '}';
        }
    }
}


