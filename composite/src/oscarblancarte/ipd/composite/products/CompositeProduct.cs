using System;
using System.Collections.Generic;
/**
 * @author oblancarte
 */
namespace oscarblancarte.ipd.composite.products{
    public class CompositeProduct : AbstractProduct {

        private List<AbstractProduct> products = new List<AbstractProduct>();

        public CompositeProduct(String name) : base(name, 0){
            
        }

        public double getPrice() {
            double price = 0d;
            foreach(AbstractProduct child in products) {
                price += child.getPrice();
            }
            return price;
        }

        public void setPrice(double price) {
            throw new NotSupportedException();
        }

        public void addProduct(AbstractProduct product) {
            this.products.Add(product);
        }

        public bool removeProduct(AbstractProduct product) {
            return this.products.Remove(product);
        }
    }
}


