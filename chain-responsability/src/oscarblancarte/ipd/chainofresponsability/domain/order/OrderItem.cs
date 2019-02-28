using oscarblancarte.ipd.chainofresponsability.domain;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */

namespace oscarblancarte.ipd.chainofresponsability.domain.order
{
    public class OrderItem
    {
        public Product Product{get; set;}
        public double Price{get; set;}
        public float Quantity{get; set;}

        public double getTotal()
        {
            return Price * Quantity;
        }
    }
}