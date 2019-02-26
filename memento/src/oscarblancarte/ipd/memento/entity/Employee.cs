using oscarblancarte.ipd.memento.impl;
using System;

namespace oscarblancarte.ipd.memento.entity{
    public class Employee : ICloneable {
        private string name;
        private string lastName;
        private string employeeNumber;

        public Employee(string name, string lastName, string employeeNumber) {
            this.name = name;
            this.lastName = lastName;
            this.employeeNumber = employeeNumber;
        }

        public Employee() {
        }
        
        public string getName() {
            return name;
        }

        public void setName(string name) {
            this.name = name;
        }

        public string getLastName() {
            return lastName;
        }

        public void setLastName(string lastName) {
            this.lastName = lastName;
        }

        public string getEmployeeNumber() {
            return employeeNumber;
        }

        public void setEmployeeNumber(string employeeNumber) {
            this.employeeNumber = employeeNumber;
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
            this.name = employee.name;
            this.lastName = employee.name;
            this.employeeNumber = employee.employeeNumber;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}