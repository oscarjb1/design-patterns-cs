using System.Collections.Generic;
using oscarblancarte.ipd.chainofresponsability.domain;
using oscarblancarte.ipd.chainofresponsability.domain.order;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.chainofresponsability.validator{
    public class OrderItemValidator : AbstractOrderValidator {

        public override void Validate(AbstractOrder order)  {
            List<OrderItem> orderItems = order.OrderItems;
            foreach (OrderItem item in orderItems) {
                Product product = item.Product;
                if (item.Quantity <= 0) {
                    throw new ValidationException("The product '" + product.Name + "' has no amount");
                } 
                
                double listPrice = item.Product.ListPrice;
                double price = item.Price;
                double priceLimit = listPrice - (listPrice*0.20d);
                if(price < priceLimit){
                    throw new ValidationException("The price of the product '"+
                            product.Name+"' exceeds the allowed limit");
                }
            }
        }
    }

}


