using System;

/**
 *
 * @author oblancarte
 */
namespace oscarblancarte.ipd.builder.dto{
    public class Address {
        private string address;
        private string city;
        private string country;
        private string cp;

        public Address() {
        }

        public Address(string address, string city, string country, string cp) {
            this.address = address;
            this.city = city;
            this.country = country;
            this.cp = cp;
        }
        
        public String getAddress() {
            return address;
        }

        public void setAddress(String address) {
            this.address = address;
        }

        public String getCity() {
            return city;
        }

        public void setCity(String city) {
            this.city = city;
        }

        public String getCountry() {
            return country;
        }

        public void setCountry(String country) {
            this.country = country;
        }

        public String getCp() {
            return cp;
        }

        public void setCp(String cp) {
            this.cp = cp;
        }

        public override string ToString() {
            return "Address{" + "address=" + address + ", city=" + city + ", country=" + country + ", cp=" + cp + '}';
        }
    }
}


