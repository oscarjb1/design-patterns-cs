using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.chainofresponsability.domain.order{
    public class SalesOrder : AbstractOrder{
        protected DateTime deliveryDate;

        public DateTime getDeliveryDate() {
            return deliveryDate;
        }

        public void setDeliveryDate(DateTime deliveryDate) {
            this.deliveryDate = deliveryDate;
        }
        
    }
}



