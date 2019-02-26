using oscarblancarte.ipd.chainofresponsability.domain;
using oscarblancarte.ipd.chainofresponsability.domain.order;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
    namespace oscarblancarte.ipd.chainofresponsability.validator{
    public class CreditValidator : AbstractOrderValidator{

        public override void validate(AbstractOrder order) {
            double total = order.getTotal();
            CreditData creditData = order.getContributor().getCreditData();
            double newBalance = creditData.getBalance() + total;
            if(newBalance > creditData.getCreditLimit()){
                throw new ValidationException("The amount of the order  " + "exceeds the available credit limit");
            }
        }
    }
}


