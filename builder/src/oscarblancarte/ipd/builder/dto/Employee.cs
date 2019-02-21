using oscarblancarte.ipd.builder;
using System.Collections.Generic;
using System;

/**
 * @author oblancarte
 */
namespace oscarblancarte.ipd.builder.dto{
    public class Employee {

        private string name;
        private int age;
        private string gender;
        private Address adress;
        private List<Phone> phones;
        private List<Contact> contacs;

        private Employee(string name, int age, string gender, Address adress, List<Phone> phones, List<Contact> contacs) {
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.adress = adress;
            this.phones = phones;
            this.contacs = contacs;
        }

        public Employee(string name, int age, string gender) {
            this.name = name;
            this.age = age;
            this.gender = gender;
        }

        public Employee() {
        }

        public string getName() {
            return name;
        }

        public void setName(string name) {
            this.name = name;
        }

        public int getAge() {
            return age;
        }

        public void setAge(int age) {
            this.age = age;
        }

        public string getGender() {
            return gender;
        }

        public void setGender(string gender) {
            this.gender = gender;
        }

        public Address getAdress() {
            return adress;
        }

        public void setAdress(Address adress) {
            this.adress = adress;
        }

        public List<Phone> getPhones() {
            return phones;
        }

        public void setPhones(List<Phone> phones) {
            this.phones = phones;
        }

        public List<Contact> getContacs() {
            return contacs;
        }

        public void setContacs(List<Contact> contacs) {
            this.contacs = contacs;
        }

        public override string ToString() {
            return "Employee{" + "name=" + name + ", age=" + age + ", gender=" 
                    + gender + ", \nadress=" + adress + ", \nphones=" + string.Join(" ", phones) 
                    + ", \ncontacs=" + string.Join(" ", contacs) + '}';
        }
        
        public class EmployeeBuilder : IBuilder<Employee>{

            private string name;
            private int age;
            private string gender;
            private Address adress;
            private readonly List<Phone> phones = new List<Phone>();
            private readonly List<Contact> contacs = new List<Contact>();

            public EmployeeBuilder() {
            }

            public EmployeeBuilder setName(string name) {
                this.name = name;
                return this;
            }

            public EmployeeBuilder setAge(int age) {
                this.age = age;
                return this;
            }

            public EmployeeBuilder setGender(string gender) {
                this.gender = gender;
                return this;
            }

            public EmployeeBuilder setAdress(string address, string city, 
                    string country, string cp) {
                adress = new Address(address, city, country, cp);
                return this;
            }

            public EmployeeBuilder addPhones(string phoneNumber, string ext, 
                    string phoneType) {
                phones.Add(new Phone(phoneNumber, ext, phoneType));
                return this;
            }

            public EmployeeBuilder addContacs(string name, string phoneNumber, 
                    string ext, string phoneType,string address, string city, 
                    string country, string cp) {
                contacs.Add(new Contact(name, new Phone(phoneNumber, ext, phoneType)
                        ,new Address(address, city, country, cp)));
                return this;
            }
            
            public EmployeeBuilder addContacs(string name, string phoneNumber, 
                    string ext, string phoneType) {
                contacs.Add(new Contact(name, new Phone(phoneNumber, ext, phoneType)));
                return this;
            }

            public Employee build() {
                return new Employee(name, age, gender, adress, phones, contacs);
            }
        }
    }

}


