using oscarblancarte.ipd.chainofresponsability.domain;
using System;
using System.Collections.Generic;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */

namespace oscarblancarte.ipd.chainofresponsability.domain.order{
    public abstract class AbstractOrder {
    private DateTime createDate;
    private Contributor contributor;
    private List<OrderItem> orderItems;

    public DateTime getCreateDate() {
        return createDate;
    }

    public void setCreateDate(DateTime createDate) {
        this.createDate = createDate;
    }

    public Contributor getContributor() {
        return contributor;
    }

    public void setContributor(Contributor contributor) {
        this.contributor = contributor;
    }

    public List<OrderItem> getOrderItems() {
        return orderItems;
    }

    public void setOrderItems(List<OrderItem> orderItems) {
        this.orderItems = orderItems;
    }
    
    public double getTotal(){
        double total = 0d;
        foreach(OrderItem abstractOrderItem in orderItems) {
            total+=abstractOrderItem.getTotal();
        }
        return total;
    }
    
}

}


