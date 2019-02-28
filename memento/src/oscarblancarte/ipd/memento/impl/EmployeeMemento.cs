
using oscarblancarte.ipd.memento.entity;

namespace oscarblancarte.ipd.memento.impl{
    public class EmployeeMemento {
        
        public Employee Employee;
        
        public EmployeeMemento(Employee Employee){
            this.Employee = Employee;
        }
        
        public Employee getMemento(){
            return Employee;
        }
    }
}


