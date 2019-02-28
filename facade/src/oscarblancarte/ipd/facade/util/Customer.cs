using System;
/**
 * @author Oscar Javier Blancarte Iturralde.
 * @see http://oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.facade.util{
    public class Customer {

        public Int64 Id{get; set;}
        public string Name{get; set;}
        public double Balance{get; set;}
        public string Status{get; set;}

        public Customer() {
        }

        public Customer(Int64 id, string name, double balance, string status) {
            this.Id = id;
            this.Name = name;
            this.Balance = balance;
            this.Status = status;
        }

        

        public override string ToString() {
            return "Customer{" + "id=" + Id + ", name=" + Name + ", "
                    + "\nbalance=" + Balance + ", status=" + Status + '}';
        }

    }

}


