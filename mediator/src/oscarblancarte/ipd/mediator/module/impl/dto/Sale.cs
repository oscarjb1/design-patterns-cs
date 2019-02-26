using System;
using System.Collections.Generic;

namespace oscarblancarte.ipd.mediator.module.impl.dto
{

    public class Sale
    {

        protected List<Product> productos = new List<Product>();

        public List<Product> getProductos()
        {
            return productos;
        }

        public void addProduct(Product product)
        {
            this.productos.Add(product);
        }

        public void setProductos(List<Product> productos)
        {
            this.productos = productos;
        }

    }
}


