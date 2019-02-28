using oscarblancarte.ipd.memento.impl;
using System;

namespace oscarblancarte.ipd.memento.entity{
    public class Employee : ICloneable {
        public string Name{get; set;}
        public string LastName{get; set;}
        public string EmployeeNumber{get; set;}

        public Employee(){

        }

        public Employee(string Name, string LastName, string EmployeeNumber) {
            this.Name = Name;
            this.LastName = LastName;
            this.EmployeeNumber = EmployeeNumber;
        }

        public EmployeeMemento createMemento(){
            try {
                return new EmployeeMemento((Employee)this.Clone());
            } catch (Exception ) {
                throw new SystemException("Error cloning the employee");
            }
        }
        
        public void restoreMemento(EmployeeMemento memento){
            Employee employee = memento.getMemento();
            this.Name = employee.Name;
            this.LastName = employee.LastName;
            this.EmployeeNumber = employee.EmployeeNumber;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}