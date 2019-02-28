using System;
using System.Collections.Generic;
/**
 * @author oblancarte
 */
namespace oscarblancarte.ipd.composite.products{
    public class CompositeProduct : AbstractProduct {

        private List<AbstractProduct> Products = new List<AbstractProduct>();

        public CompositeProduct(String name) : base(name, 0){
            
        }

        public double GetPrice() {
            double price = 0d;
            foreach(AbstractProduct child in Products) {
                price += child.Price;
            }
            return price;
        }

        public void SetPrice(double price) {
            throw new NotSupportedException();
        }

        public void AddProduct(AbstractProduct product) {
            this.Products.Add(product);
        }

        public bool RemoveProduct(AbstractProduct product) {
            return this.Products.Remove(product);
        }
    }
}


