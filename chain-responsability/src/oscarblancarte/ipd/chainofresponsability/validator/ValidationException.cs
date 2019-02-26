using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */

namespace oscarblancarte.ipd.chainofresponsability.validator{
    public class ValidationException : Exception {

        public ValidationException(String message) : base(message)  {
        }
    }
}


