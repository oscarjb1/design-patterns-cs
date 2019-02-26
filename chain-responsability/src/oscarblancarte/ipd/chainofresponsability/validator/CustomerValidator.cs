using oscarblancarte.ipd.chainofresponsability.domain;
using oscarblancarte.ipd.chainofresponsability.domain.order;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.chainofresponsability.validator{
    public class CustomerValidator : AbstractOrderValidator{
        
        public override void validate(AbstractOrder order) {
            foreach(AbstractOrderValidator validator in validators){
                validator.validate(order);
            }
            //if (c.GetType() == typeof(TForm))

            if(!(order.getContributor().GetType() == typeof(Customer)) ){
                throw new ValidationException("The taxpayer is not a client");
            }
        }
    }
}


