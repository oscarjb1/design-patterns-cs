using System;

namespace oscarblancarte.ipd.nullobject.domain{
    public class Employee {

        public static readonly Employee NULL_EMPOYEE = new Employee(0L,"UNKNOW EMPLOYEE",Address.NULL_ADDRESS);
        private Int64 id;
        private string name;
        private Address address;

        public Employee(Int64 id, string name, string address) {
            this.id = id;
            this.name = name;
            this.address = new Address(address);
        }

        public Employee(Int64 id, string name, Address address) {
            this.id = id;
            this.name = name;
            this.address = address;
        }

        public Employee() {
        }

        public Int64 getId() {
            return id;
        }

        public void setId(Int64 id) {
            this.id = id;
        }

        public string getName() {
            return name;
        }

        public void setName(string name) {
            this.name = name;
        }

        public Address getAddress() {
            return this.address;
        }

        public void setAddress(Address address) {
            this.address = address;
        }
    }
}