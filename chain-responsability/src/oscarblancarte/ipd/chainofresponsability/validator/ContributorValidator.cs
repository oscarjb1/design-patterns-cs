using oscarblancarte.ipd.chainofresponsability.domain;
using oscarblancarte.ipd.chainofresponsability.domain.order;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.chainofresponsability.validator{
    public class ContributorValidator : AbstractOrderValidator{
        
        public override void validate(AbstractOrder order)  {
            foreach(AbstractOrderValidator validator in validators){
                validator.validate(order);
            }
            Contributor contributor = order.getContributor();
            if(Status.ACTIVO != contributor.getStatus()){
                throw new ValidationException("The taxpayer is not active");
            }
        }
    }
}



