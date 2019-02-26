using oscarblancarte.ipd.chainofresponsability.domain.order;
using System;
using System.Collections.Generic;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.chainofresponsability.validator{
    public abstract class AbstractOrderValidator {
        
        protected List<AbstractOrderValidator> validators = new List<AbstractOrderValidator>();
        
        public abstract void validate(AbstractOrder order) ;
        
        public void addValidator(AbstractOrderValidator validator){
            validators.Add(validator);
        }
    }
}



