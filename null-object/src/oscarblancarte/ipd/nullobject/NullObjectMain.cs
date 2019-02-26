using oscarblancarte.ipd.nullobject.dao;
using oscarblancarte.ipd.nullobject.domain;
using System;

namespace oscarblancarte.ipd.nullobject{
    public class NullObjectMain {
        static void Main(string[] args) {
            EmployeeDAOService service = new EmployeeDAOService();
            Employee emp1 = service.findEmployeeById(1L);
            Console.WriteLine(emp1.getAddress().getFullAddress());

            Employee emp2 = service.findEmployeeById(2L);
            Console.WriteLine(emp2.getAddress().getFullAddress());
        }
    }
}


