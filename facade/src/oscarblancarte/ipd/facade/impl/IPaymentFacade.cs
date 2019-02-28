/**
 * @author Oscar Javier Blancarte Iturralde.
 * @see http://oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.facade.impl{
    public interface IPaymentFacade {
        PaymentResponse Pay(PaymentRequest paymentRequest);
    }
}


