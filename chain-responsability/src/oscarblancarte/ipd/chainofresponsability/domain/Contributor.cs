using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.chainofresponsability.domain{
    public abstract class Contributor {

        public string Name{get; set;}
        public string Rfc{get; set;}
        public Status Status{get; set;}
        
        public Address Address{get; set;}
        public Telephone Telephone{get; set;}
        public CreditData CreditData{get; set;}
    }
}