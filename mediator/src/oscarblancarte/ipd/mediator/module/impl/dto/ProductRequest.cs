using System;
using System.Collections.Generic;


namespace oscarblancarte.ipd.mediator.module.impl.dto{
    public class ProductRequest {
        public List<Product> products = new List<Product>();

        public List<Product> getProducts() {
            return products;
        }

        public void setProducts(List<Product> products) {
            this.products = products;
        }
    }
}


