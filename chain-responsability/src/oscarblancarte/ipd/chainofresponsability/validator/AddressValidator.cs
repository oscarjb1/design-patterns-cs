using oscarblancarte.ipd.chainofresponsability.domain;
using oscarblancarte.ipd.chainofresponsability.domain.order;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.chainofresponsability.validator{
    public class AddressValidator : AbstractOrderValidator{

        public override void Validate(AbstractOrder order) {
            Address address = order.Contributor.Address;
            if(address.Address1==null || address.Address1.Length==0){
                throw new ValidationException("Address 1 is mandatory");
            }else if(address.CP==null || address.CP.Length!=4){
                throw new ValidationException("ZIP code must be 4 digits");
            }else if(address.Country==null || address.Country.Length==0){
                throw new ValidationException("The country is mandatory");
            }
        }
    }
}