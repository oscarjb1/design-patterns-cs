using oscarblancarte.ipd.chainofresponsability.domain;
using oscarblancarte.ipd.chainofresponsability.domain.order;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.chainofresponsability.validator{
    public class CustomerValidator : AbstractOrderValidator{
        
        public override void Validate(AbstractOrder order) {
            foreach(AbstractOrderValidator validator in Validators){
                validator.Validate(order);
            }
            //if (c.GetType() == typeof(TForm))

            if(!(order.Contributor.GetType() == typeof(Customer)) ){
                throw new ValidationException("The taxpayer is not a client");
            }
        }
    }
}


