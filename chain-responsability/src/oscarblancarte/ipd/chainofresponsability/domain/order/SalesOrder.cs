using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.chainofresponsability.domain.order{
    public class SalesOrder : AbstractOrder{
        public DateTime DeliveryDate{get; set;}
        
    }
}



