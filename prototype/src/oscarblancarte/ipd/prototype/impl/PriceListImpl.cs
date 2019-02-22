using System.Collections.Generic;

/**
 * @author oscar javier blancarte iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.prototype.impl{
    public class PriceListImpl : IPrototype{
        private string listName;
        private List<ProductItem> products = new List<ProductItem>();

        public PriceListImpl(string listName) {
            this.listName = listName;
        }
        
        public List<ProductItem> getProducts() {
            return products;
        }

        public void setProducts(List<ProductItem> products) {
            this.products = products;
        }

        public string getListName() {
            return listName;
        }

        public void setListName(string listName) {
            this.listName = listName;
        }
        
        public void addProductItem(ProductItem item){
            this.products.Add(item);
        }
        
        public IPrototype clone() {
            PriceListImpl clone = new PriceListImpl(listName);
            clone.setProducts(products);
            return clone;
        }

        public IPrototype deepClone() {
            List<ProductItem> cloneProducts = new List<ProductItem>();
            foreach(ProductItem item in this.products){
                ProductItem cloneItem = (ProductItem)item.clone();
                cloneProducts.Add(cloneItem);
            }
            PriceListImpl clone = new PriceListImpl(listName);
            clone.setProducts(cloneProducts);
            return clone;
        }

        public override string ToString() {
            string items = "";
            foreach(ProductItem item in this.products){
                items += "\t" + item.ToString() + "\n";
            }
            return "PriceListImpl{listName=" + listName + ", products=\n" + items + '}';
        }
    }
}



