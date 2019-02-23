using System;

/**
 * @author oblancarte
 */
namespace oscarblancarte.ipd.composite.products{
    public abstract class AbstractProduct {

        protected string name;
        protected double price;

        public AbstractProduct(string name, double price) {
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
    }
}


