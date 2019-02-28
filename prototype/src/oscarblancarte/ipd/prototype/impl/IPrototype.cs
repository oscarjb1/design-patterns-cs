using oscarblancarte.ipd.prototype.impl;
using System;

/**
 * @author oscar javier blancarte iturralde
 * @see http://www.oscarblancarteblog.com
 */

namespace oscarblancarte.ipd.prototype.impl{
    public interface IPrototype
    {
        IPrototype Clone();
        IPrototype DeepClone();
    }
}

