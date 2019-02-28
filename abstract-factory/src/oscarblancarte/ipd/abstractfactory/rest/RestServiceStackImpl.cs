using oscarblancarte.ipd.abstractfactory.impl;
using oscarblancarte.ipd.abstractfactory.service;
using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */

namespace oscarblancarte.ipd.abstractfactory.rest{
    public class RestServiceStackImpl : IServiceStackAbstractFactory{
        public IEmployeeService GetEmployeeService() {
            return new EmployeeServiceRestImpl();
        }

        public IProductsService GetProductsService() {
            return new ProductServiceRestImpl();
        }
    }
}




