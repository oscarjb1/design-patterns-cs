using oscarblancarte.ipd.chainofresponsability.domain.order;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.chainofresponsability.validator{
    public class SalesOrderValidator : AbstractOrderValidator {

        public override void validate(AbstractOrder order)  {
            if (!(order.GetType() == typeof(SalesOrder))) {
                throw new ValidationException("A sales order was expected");
            }

            foreach(AbstractOrderValidator validator in validators){
                validator.validate(order);
            }
        }
    }

}


