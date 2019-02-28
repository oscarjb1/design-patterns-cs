using oscarblancarte.ipd.chainofresponsability.domain;
using System;
using System.Collections.Generic;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */

namespace oscarblancarte.ipd.chainofresponsability.domain.order
{
    public abstract class AbstractOrder
    {
        public DateTime CreateDate { get; set; }
        public Contributor Contributor { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public double getTotal()
        {
            double total = 0d;
            foreach (OrderItem abstractOrderItem in OrderItems)
            {
                total += abstractOrderItem.getTotal();
            }
            return total;
        }
    }
}