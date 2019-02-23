using oscarblancarte.ipd.iterator.impl;
using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.iterator{
        public class IteratorMain {

                static void Main(string[] args) {
                        Employee employee = new Employee("Juan", "CEO",
                                new Employee("Pedro", "President",
                                        new Employee("Liliana", "VP",
                                                new Employee("Oscar", "Manager",
                                                        new Employee("Mario", "Developer"),
                                                        new Employee("Rodolfo", "Developer")),
                                                new Employee("Sofia", "Manager",
                                                        new Employee("Adrian", "Sr Developer"),
                                                        new Employee("Rebeca", "Developer")
                                                )
                                        )
                                )
                        );


                        IIterator<Employee> empIterator = employee.createIterator();
                        while (empIterator.hasNext()) {
                                Employee emp = empIterator.next();
                                Console.WriteLine("emp > " + emp.ToString());
                        }
                }
        }
}


