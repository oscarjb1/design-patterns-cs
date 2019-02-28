
using System;
using System.Collections.Generic;
using System.Linq;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.iterator.impl{

    public class Employee : IContainer<Employee> {

        public String Name{get; set;}
        public String Role{get; set;}
        public List<Employee> Subordinates{get; set;}

        public Employee(String role, String puesto, params Employee[] subordinates) {
            this.Name = role;
            this.Role = puesto;
            this.Subordinates = subordinates.OfType<Employee>().ToList();
            
        }

        public IIterator<Employee> CreateIterator() {
            return new TreeEmployeeIterator(this);
        }

        public Employee getThis(){
            return this;
        }

        

        public void addSubordinate(Employee subordinate) {
            if (subordinate == null) {
                Subordinates = new List<Employee>();
            }
            Subordinates.Add(subordinate);
        }

        public override string ToString() {
            return "Employee{" + "name=" + Name + ", role=" + Role + '}';
        }

        private class TreeEmployeeIterator : IIterator<Employee> {

            private List<Employee> list = new List<Employee>();
            private int index = 0;

            private Employee employee;

            public TreeEmployeeIterator(Employee employee){
                this.employee = employee;
                addRecursive(this.employee);
            }

            public void addRecursive(Employee employee) {
                list.Add(employee);
                if (employee.Subordinates != null) {
                    foreach (Employee subordinate in employee.Subordinates) {
                        addRecursive(subordinate);
                    }
                }
            }

            public bool HasNext() {
                if (list.Count == 0) {
                    return false;
                }

                return index < list.Count;
            }

            public Employee Next() {
                if (!HasNext()) {
                    throw new SystemException("there are no more elements");
                }
                return list[index++];
            }
        }
    }
}
