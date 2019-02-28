using System;

/**
 * @author oblancarte
 */
namespace oscarblancarte.ipd.composite.products{
    public abstract class AbstractProduct {

        public string Name{get; set;}
        public double Price{get; set;}

        public AbstractProduct(string name, double price) {
            this.Name = name;
            this.Price = price;
        }
    }
}