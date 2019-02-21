using oscarblancarte.ipd.factorymethod.dao;
using oscarblancarte.ipd.factorymethod.entity;
using System;
using System.Collections.Generic;

namespace oscarblancarte.ipd.factorymethod{
    public class FactoryMain {

        static void Main(string[] args)  {
            //Creamos los nuevos productos a registrar
            Product productA = new Product(1L, "Product A", 100);
            Product productB = new Product(2L, "Product B", 100);
            
            //Creation of the DAO instance  
            ProductDAO productDAO = new ProductDAO();
            
            //Product persist  
            productDAO.saveProduct(productA);
            productDAO.saveProduct(productB);
            
            //Create the products  
            List<Product> products = productDAO.findAllProducts();

            Console.WriteLine("Product size ==> " + products.Count);
            foreach(Product product in products){
                Console.WriteLine(product);
            }
        }
    }
}


