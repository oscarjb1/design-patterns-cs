using oscarblancarte.ipd.abstractfactory.service;
using System;


/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */

namespace oscarblancarte.ipd.abstractfactory.rest{
    public class ProductServiceRestImpl : IProductsService{
        private static readonly string[] PRODUCTS = new string[]{"keyboard","Mouse","Display"};

        public string[] GetProducts() {
            Console.WriteLine("RestFul");
            return PRODUCTS;
        }
    }
}





