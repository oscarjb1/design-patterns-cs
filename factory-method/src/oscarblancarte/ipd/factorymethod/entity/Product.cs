using System;

/**
 * @author oblancarte
 */
namespace oscarblancarte.ipd.factorymethod.entity{

    public class Product {
        public Int64 IdProduct{get;set;}
        public String ProductName{get; set;}
        public double Price{get;set;}

        public Product(Int64 idProduct, string productName, double price) {
            this.IdProduct = idProduct;
            this.ProductName = productName;
            this.Price = price;
        }

        public Product() {
        }

        

        public string toString() {
            return "Product{" + "idProduct=" + IdProduct + ", productName=" + ProductName + ", price=" + Price + '}';
        }
    }

}

