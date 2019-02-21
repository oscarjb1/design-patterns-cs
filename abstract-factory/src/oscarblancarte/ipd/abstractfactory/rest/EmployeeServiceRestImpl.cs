using System;
using oscarblancarte.ipd.abstractfactory.service;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */

namespace oscarblancarte.ipd.abstractfactory.rest{
    public class EmployeeServiceRestImpl : IEmployeeService{
        private static readonly string[] EMPLOYEES = new string[]{"Juan","Pedro","Manuel"};

        public string[] getEmployee() {
            Console.WriteLine("RestFul");
            return EMPLOYEES;
        }
    }
}




