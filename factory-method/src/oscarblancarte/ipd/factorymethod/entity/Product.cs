using System;

/**
 * @author oblancarte
 */
namespace oscarblancarte.ipd.factorymethod.entity{

    public class Product {
        private Int64 idProduct;
        private String productName;
        private double price;

        public Product(Int64 idProduct, string productName, double price) {
            this.idProduct = idProduct;
            this.productName = productName;
            this.price = price;
        }

        public Product() {
        }

        public Int64 getIdProduct() {
            return idProduct;
        }

        public void setIdProduct(Int64 idProduct) {
            this.idProduct = idProduct;
        }

        public string getProductName() {
            return productName;
        }

        public void setProductName(string productName) {
            this.productName = productName;
        }

        public double getPrice() {
            return price;
        }

        public void setPrice(double price) {
            this.price = price;
        }

        public string toString() {
            return "Product{" + "idProduct=" + idProduct + ", productName=" + productName + ", price=" + price + '}';
        }
    }

}

