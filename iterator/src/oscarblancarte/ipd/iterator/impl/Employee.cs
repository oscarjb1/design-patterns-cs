
using System;
using System.Collections.Generic;
using System.Linq;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.iterator.impl{

    public class Employee : IContainer<Employee> {

        private String name;
        private String role;
        private List<Employee> subordinates;

        public Employee(String role, String puesto, params Employee[] subordinates) {
            this.name = role;
            this.role = puesto;
            this.subordinates = subordinates.OfType<Employee>().ToList();
            
        }

        public IIterator<Employee> createIterator() {
            return new TreeEmployeeIterator(this);
        }

        public Employee getThis(){
            return this;
        }

        

        public String getRole() {
            return name;
        }

        public void setRole(String name) {
            this.name = name;
        }

        public String getPuesto() {
            return role;
        }

        public void setPuesto(String puesto) {
            this.role = puesto;
        }

        public List<Employee> getSubordinates() {
            return subordinates;
        }

        public void setSubordinates(List<Employee> subordinates) {
            this.subordinates = subordinates;
        }

        public void addSubordinate(Employee subordinate) {
            if (subordinate == null) {
                subordinates = new List<Employee>();
            }
            subordinates.Add(subordinate);
        }

        public override string ToString() {
            return "Employee{" + "name=" + name + ", role=" + role + '}';
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
                if (employee.getSubordinates() != null) {
                    foreach (Employee subordinate in employee.getSubordinates()) {
                        addRecursive(subordinate);
                    }
                }
            }

            public bool hasNext() {
                if (list.Count == 0) {
                    return false;
                }

                return index < list.Count;
            }

            public Employee next() {
                if (!hasNext()) {
                    throw new SystemException("there are no more elements");
                }
                return list[index++];
            }
        }
    }
}
