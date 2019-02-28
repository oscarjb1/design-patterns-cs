using System;
using System.Collections.Generic;


namespace oscarblancarte.ipd.mediator.module.impl.dto{
    public class ProductRequest {
        public List<Product> Products;

        public ProductRequest(){
            this.Products = new List<Product>();
        }
    }
}