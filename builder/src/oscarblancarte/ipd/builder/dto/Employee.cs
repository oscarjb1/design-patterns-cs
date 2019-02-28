using oscarblancarte.ipd.builder;
using System.Collections.Generic;
using System;

/**
 * @author oblancarte
 */
namespace oscarblancarte.ipd.builder.dto{
    public class Employee {

        public string Name{get;set;}
        public int Age{get;set;}
        public string Gender{get;set;}
        public Address Adress{get;set;}
        public List<Phone> Phones{get;set;}
        public List<Contact> Contacs{get;set;}

        private Employee(string name, int age, string gender, Address adress, List<Phone> phones, List<Contact> contacs) {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
            this.Adress = adress;
            this.Phones = phones;
            this.Contacs = contacs;
        }

        public Employee(string name, int age, string gender) {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public Employee() {
        }

        public override string ToString() {
            return "Employee{" + "name=" + Name + ", age=" + Age + ", gender=" 
                    + Gender + ", \nadress=" + Adress + ", \nphones=" + string.Join(" ", Phones) 
                    + ", \ncontacs=" + string.Join(" ", Contacs) + '}';
        }
        
        public class EmployeeBuilder : IBuilder<Employee>{

            private string Name;
            private int Age;
            private string Gender;
            private Address Adress;
            private readonly List<Phone> Phones = new List<Phone>();
            private readonly List<Contact> Contacs = new List<Contact>();

            public EmployeeBuilder() {
            }

            public EmployeeBuilder setName(string name) {
                this.Name = name;
                return this;
            }

            public EmployeeBuilder setAge(int age) {
                this.Age = age;
                return this;
            }

            public EmployeeBuilder setGender(string gender) {
                this.Gender = gender;
                return this;
            }

            public EmployeeBuilder setAdress(string address, string city, 
                    string country, string cp) {
                Adress = new Address(address, city, country, cp);
                return this;
            }

            public EmployeeBuilder addPhones(string phoneNumber, string ext, 
                    string phoneType) {
                Phones.Add(new Phone(phoneNumber, ext, phoneType));
                return this;
            }

            public EmployeeBuilder addContacs(string name, string phoneNumber, 
                    string ext, string phoneType,string address, string city, 
                    string country, string cp) {
                Contacs.Add(new Contact(name, new Phone(phoneNumber, ext, phoneType)
                        ,new Address(address, city, country, cp)));
                return this;
            }
            
            public EmployeeBuilder addContacs(string name, string phoneNumber, 
                    string ext, string phoneType) {
                Contacs.Add(new Contact(name, new Phone(phoneNumber, ext, phoneType)));
                return this;
            }

            public Employee Build() {
                return new Employee(Name, Age, Gender, Adress, Phones, Contacs);
            }
        }
    }

}


