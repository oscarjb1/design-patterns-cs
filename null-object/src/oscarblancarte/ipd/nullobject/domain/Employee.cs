using System;

namespace oscarblancarte.ipd.nullobject.domain{
    public class Employee {

        public static readonly Employee NULL_EMPOYEE = new Employee(0L,"UNKNOW EMPLOYEE",Address.NULL_ADDRESS);
        public Int64 Id{get; set;}
        public string Name{get; set;}
        public Address Address{get; set;}

        public Employee(Int64 Id, string Name, string Address) {
            this.Id = Id;
            this.Name = Name;
            this.Address = new Address(Address);
        }

        public Employee(Int64 Id, string Name, Address Address) {
            this.Id = Id;
            this.Name = Name;
            this.Address = Address;
        }

        public Employee() {
        }
    }
}