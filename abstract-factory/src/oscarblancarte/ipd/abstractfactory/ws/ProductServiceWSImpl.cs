using oscarblancarte.ipd.abstractfactory.service;
using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.abstractfactory.ws{
    public class ProductServiceWSImpl : IProductsService {

        private static readonly string[] PRODUCTS = new string[]{"Soda", "Juice", "Fruit"};

        public string[] GetProducts() {
            Console.WriteLine("WebServices");
            return PRODUCTS;
        }
    }
}




