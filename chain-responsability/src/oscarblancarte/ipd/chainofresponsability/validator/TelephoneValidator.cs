using oscarblancarte.ipd.chainofresponsability.domain;
using oscarblancarte.ipd.chainofresponsability.domain.order;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.chainofresponsability.validator{
    public class TelephoneValidator : AbstractOrderValidator{

        public override void validate(AbstractOrder order) {
            Telephone tel = order.getContributor().getTelephone();
            if(null == tel){
                throw new ValidationException(
                        "The taxpayer's phone is required");
            }else if(tel.getNumber().Length!= 7){
                throw new ValidationException("Invalid phone number");
            }else if(tel.getLada().Length!=3){
                throw new ValidationException("Invalid lada");
            }
        }
    }

}


