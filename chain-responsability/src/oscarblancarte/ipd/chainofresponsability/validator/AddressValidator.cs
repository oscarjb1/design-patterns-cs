using oscarblancarte.ipd.chainofresponsability.domain;
using oscarblancarte.ipd.chainofresponsability.domain.order;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.chainofresponsability.validator{
    public class AddressValidator : AbstractOrderValidator{

        public override void validate(AbstractOrder order) {
            Address address = order.getContributor().getAddress();
            if(address.getAddress1()==null || address.getAddress1().Length==0){
                throw new ValidationException("Address 1 is mandatory");
            }else if(address.getCP()==null || address.getCP().Length!=4){
                throw new ValidationException("ZIP code must be 4 digits");
            }else if(address.getCountry()==null || address.getCountry().Length==0){
                throw new ValidationException("The country is mandatory");
            }
        }
    }
}



