using System;
using System.Collections.Generic;

namespace oscarblancarte.ipd.mediator.module.impl.dto
{

    public class Sale
    {

        public List<Product> Productos{get; set;}

        public Sale(){
            Productos = new List<Product>();
        }

        public void addProduct(Product product)
        {
            this.Productos.Add(product);
        }

    }
}


