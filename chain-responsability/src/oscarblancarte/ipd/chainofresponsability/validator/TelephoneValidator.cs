using oscarblancarte.ipd.chainofresponsability.domain;
using oscarblancarte.ipd.chainofresponsability.domain.order;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.chainofresponsability.validator{
    public class TelephoneValidator : AbstractOrderValidator{

        public override void Validate(AbstractOrder order) {
            Telephone tel = order.Contributor.Telephone;
            if(null == tel){
                throw new ValidationException("The taxpayer's phone is required");
            }else if(tel.Number.Length!= 7){
                throw new ValidationException("Invalid phone number");
            }else if(tel.Lada.Length!=3){
                throw new ValidationException("Invalid lada");
            }
        }
    }
}