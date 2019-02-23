using System;
/**
 * @author Oscar Javier Blancarte Iturralde.
 * @see http://oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.facade.util{
    public class Customer {

        private Int64 id;
        private string name;
        private double balance;
        private string status;

        public Customer() {
        }

        public Customer(Int64 id, string name, double balance, string status) {
            this.id = id;
            this.name = name;
            this.balance = balance;
            this.status = status;
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

        public double getBalance() {
            return balance;
        }

        public void setBalance(double balance) {
            this.balance = balance;
        }

        public string getStatus() {
            return status;
        }

        public void setStatus(string status) {
            this.status = status;
        }

        public override string ToString() {
            return "Customer{" + "id=" + id + ", name=" + name + ", "
                    + "\nbalance=" + balance + ", status=" + status + '}';
        }

    }

}


