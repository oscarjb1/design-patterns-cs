
using oscarblancarte.ipd.memento.entity;

namespace oscarblancarte.ipd.memento.impl{
    public class EmployeeMemento {
        
        public Employee employee;
        
        public EmployeeMemento(Employee employee){
            this.employee = employee;
        }
        
        public Employee getMemento(){
            return employee;
        }
    }
}


