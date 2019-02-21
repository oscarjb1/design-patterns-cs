using oscarblancarte.ipd.abstractfactory.service;
using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
    namespace oscarblancarte.ipd.abstractfactory.ws{
    public class EmployeeServiceWSImpl : IEmployeeService {

        private static readonly string[] EMPLOYEES = new string[]{"Maria", "Rebeca", "Liliana"};

        public string[] getEmployee() {
            Console.WriteLine("WebServices");
            return EMPLOYEES;
        }

    }
}





