/**
 * @author oblancarte
 */
namespace oscarblancarte.ipd.composite.products{
    public class SimpleProduct : AbstractProduct {

        public string Brand{get; set;}

        public SimpleProduct(string name, double price, string brand): base(name, price) {
            
            this.Brand = brand;
        }

        
    }
}


