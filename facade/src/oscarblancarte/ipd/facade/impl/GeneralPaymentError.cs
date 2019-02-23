using System;

/**
 * @author Oscar Javier Blancarte Iturralde.
 * @see http://oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.facade.impl{
    public class GeneralPaymentError : Exception {

        public GeneralPaymentError(string message) : base(message){
            
        }
    }
}