using oscarblancarte.ipd.chainofresponsability.domain.order;
using System;
using System.Collections.Generic;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.chainofresponsability.validator{
    public abstract class AbstractOrderValidator {
        
        protected List<AbstractOrderValidator> Validators = new List<AbstractOrderValidator>();
        
        public abstract void Validate(AbstractOrder order) ;
        
        public void AddValidator(AbstractOrderValidator validator){
            Validators.Add(validator);
        }
    }
}



