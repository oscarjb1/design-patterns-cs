
using System;
using System.Collections.Generic;
using oscarblancarte.ipd.prototype.impl;

/**
 * @author oscar javier blancarte iturralde
 * @see http://www.oscarblancarteblog.com
 */

namespace oscarblancarte.ipd.prototype.impl{
    public class PrototypeFactory {
        private static Dictionary<string,IPrototype> Prototypes = new Dictionary<string, IPrototype>();
        
        public static IPrototype GetPrototype(string prototypeName){
            return Prototypes[prototypeName].DeepClone();
        }
        
        public static void AddPrototype(string prototypeName,IPrototype prototype){
            Prototypes.Add(prototypeName, prototype);
        }
    }
}
