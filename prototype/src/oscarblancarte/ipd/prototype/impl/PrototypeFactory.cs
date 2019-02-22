
using System;
using System.Collections.Generic;
using oscarblancarte.ipd.prototype.impl;

/**
 * @author oscar javier blancarte iturralde
 * @see http://www.oscarblancarteblog.com
 */

namespace oscarblancarte.ipd.prototype.impl{
    public class PrototypeFactory {
        private static Dictionary<string,IPrototype> prototypes = new Dictionary<string, IPrototype>();
        
        public static IPrototype getPrototype(string prototypeName){
            return prototypes[prototypeName].deepClone();
        }
        
        public static void addPrototype(string prototypeName,IPrototype prototype){
            prototypes.Add(prototypeName, prototype);
        }
    }
}
