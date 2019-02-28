using System;

using oscarblancarte.ipd.abstractfactory.service;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */

namespace oscarblancarte.ipd.abstractfactory.impl {
    public interface IServiceStackAbstractFactory {
        IEmployeeService GetEmployeeService();
        IProductsService GetProductsService();
    }
}






