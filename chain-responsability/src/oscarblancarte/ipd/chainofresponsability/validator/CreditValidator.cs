using oscarblancarte.ipd.chainofresponsability.domain;
using oscarblancarte.ipd.chainofresponsability.domain.order;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
    namespace oscarblancarte.ipd.chainofresponsability.validator{
    public class CreditValidator : AbstractOrderValidator{

        public override void Validate(AbstractOrder order) {
            double total = order.getTotal();
            CreditData creditData = order.Contributor.CreditData;
            double newBalance = creditData.Balance + total;
            if(newBalance > creditData.CreditLimit){
                throw new ValidationException("The amount of the order  " + "exceeds the available credit limit");
            }
        }
    }
}


