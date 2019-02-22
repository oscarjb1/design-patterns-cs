using oscarblancarte.ipd.prototype.impl;
using System;

/**
 * @author oscar javier blancarte iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.prototype{
    public class PrototypeMain {

        static void Main(string[] args) {
            
            //We create the initial price list
            //This has the products with the list price
            PriceListImpl standarPriceList = new PriceListImpl("Standar Price List");
            for(int c = 1; c<=5; c++){
                ProductItem item = new ProductItem("Product " + c, c*2);
                standarPriceList.addProductItem(item);
            }
            PrototypeFactory.addPrototype(standarPriceList.getListName(), standarPriceList);
            
            //Second list for wholesale customers from the list
            //standard with a 10% discount on the standard price list.
            PriceListImpl wholesalePriceList = (PriceListImpl) PrototypeFactory.getPrototype("Standar Price List");
            wholesalePriceList.setListName("Wholesale Price List");
            foreach(ProductItem item in wholesalePriceList.getProducts()){
                item.setPrice(item.getPrice()*0.90);
            }
            PrototypeFactory.addPrototype(wholesalePriceList.getListName(), wholesalePriceList);
            
            //Third price list for VIP customers from the list
            //wholesale with 10% on the wholesale price list.
            PriceListImpl vipPriceList = (PriceListImpl) PrototypeFactory.getPrototype("Wholesale Price List");
            vipPriceList.setListName("VIP Price List");
            foreach(ProductItem item in vipPriceList.getProducts()){
                item.setPrice(item.getPrice()*0.90);
            }
            
            //Imprimimos las listas de precio.
            Console.WriteLine(standarPriceList);
            Console.WriteLine(wholesalePriceList);
            Console.WriteLine(vipPriceList);
        }
    }
}




