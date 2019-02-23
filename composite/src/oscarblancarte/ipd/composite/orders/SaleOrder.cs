using oscarblancarte.ipd.composite.products;
using System;
using System.Collections.Generic;

/**
 * @author oblancarte
 */
namespace oscarblancarte.ipd.composite.orders{
    public class SaleOrder {

        private long orderId;
        private string customer;
        private List<AbstractProduct> products = new List<AbstractProduct>();

        public SaleOrder(long orderId, string customer) {
            this.orderId = orderId;
            this.customer = customer;
        }
        
        public double getPrice() {
            double price = 0d;
            foreach(AbstractProduct child in products) {
                price += child.getPrice();
            }
            return price;
        }

        public void addProduct(AbstractProduct product) {
            products.Add(product);
        }

        public void printOrder() {
            Console.WriteLine("\\\n============================================="
                    + "\nOrden: " + orderId + "\nCustomer: " + customer 
                    + "\nProducts:\n");
            foreach(AbstractProduct prod in products) {
                Console.WriteLine(prod.getName() + "\t\t\t$ " 
                        + prod.getPrice().ToString("###,##0.0000"));
            }
            Console.WriteLine("Total: " + getPrice().ToString("###,##0.0000") 
                    + "\n=============================================");
        }

        public long getOrderId() {
            return orderId;
        }

        public void setOrderId(long orderId) {
            this.orderId = orderId;
        }

        public string getCustomer() {
            return customer;
        }

        public void setCustomer(string customer) {
            this.customer = customer;
        }

        public List<AbstractProduct> getProducts() {
            return products;
        }

        public void setProducts(List<AbstractProduct> products) {
            this.products = products;
        }
    }
}


