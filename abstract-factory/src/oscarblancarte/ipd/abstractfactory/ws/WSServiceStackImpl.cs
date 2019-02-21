using oscarblancarte.ipd.abstractfactory.impl;
using oscarblancarte.ipd.abstractfactory.service;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.abstractfactory.ws{
    public class WSServiceStackImpl : IServiceStackAbstractFactory{

       public IEmployeeService getEmployeeService() {
            return new EmployeeServiceWSImpl();
        }

        public IProductsService getProductsService() {
            return new ProductServiceWSImpl();
        }
    }
}




