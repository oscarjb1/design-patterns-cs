using System.Collections.Generic;
using oscarblancarte.ipd.chainofresponsability.domain;
using oscarblancarte.ipd.chainofresponsability.domain.order;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.chainofresponsability.validator{
    public class OrderItemValidator : AbstractOrderValidator {

        public override void validate(AbstractOrder order)  {
            List<OrderItem> orderItems = order.getOrderItems();
            foreach (OrderItem item in orderItems) {
                Product product = item.getProduct();
                if (item.getQuantity() <= 0) {
                    throw new ValidationException("The product '" + product.getName() + "' has no amount");
                } 
                
                double listPrice = item.getProduct().getListPrice();
                double price = item.getPrice();
                double priceLimit = listPrice - (listPrice*0.20d);
                if(price < priceLimit){
                    throw new ValidationException("The price of the product '"+
                            product.getName()+"' exceeds the allowed limit");
                }
            }
        }
    }

}


