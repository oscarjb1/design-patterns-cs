using System;

/**
 *
 * @author oblancarte
 */
namespace oscarblancarte.ipd.builder.dto{
    public class Address {
        public string addre{get; set;}
        public string City{get; set;}
        public string Country{get; set;}
        public string Cp{get; set;}

        public Address() {
        }

        public Address(string address, string city, string country, string cp) {
            this.addre = address;
            this.City = city;
            this.Country = country;
            this.Cp = cp;
        }
        

        public override string ToString() {
            return "Address{" + "address=" + addre + ", city=" + City + ", country=" + Country + ", cp=" + Cp + '}';
        }
    }
}


