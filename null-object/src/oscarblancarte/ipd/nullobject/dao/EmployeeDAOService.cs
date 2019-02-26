using oscarblancarte.ipd.nullobject.domain;
using System.Collections.Generic;
using System;

namespace oscarblancarte.ipd.nullobject.dao{
    public class EmployeeDAOService {
        
        private List<Employee> EMPLOYEE_LIST = new List<Employee>();
        
        public EmployeeDAOService(){
            Employee emp1 = new Employee(1L, "Oscar Blancarte", new Address("Reforma 150 int 20, Mexico D.F."));
            EMPLOYEE_LIST.Add(emp1);
        }
        
        public Employee findEmployeeById(Int64 id){
            foreach(Employee emp in EMPLOYEE_LIST){
                if(emp.getId() == id){
                    return emp;
                }
            }
            return Employee.NULL_EMPOYEE;
        }
    }

}



