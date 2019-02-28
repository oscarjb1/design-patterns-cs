using oscarblancarte.ipd.chainofresponsability.domain;
using oscarblancarte.ipd.chainofresponsability.domain.order;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.chainofresponsability.validator{
    public class ContributorValidator : AbstractOrderValidator{
        
        public override void Validate(AbstractOrder order)  {
            foreach(AbstractOrderValidator validator in Validators){
                validator.Validate(order);
            }
            Contributor contributor = order.Contributor;
            if(Status.ACTIVO != contributor.Status){
                throw new ValidationException("The taxpayer is not active");
            }
        }
    }
}



