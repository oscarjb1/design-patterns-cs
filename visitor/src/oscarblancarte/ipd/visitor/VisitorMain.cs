using oscarblancarte.ipd.visitor.domain;
using oscarblancarte.ipd.visitor.impl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace oscarblancarte.ipd.visitor{
    public class VisitorMain {

        static void Main(string[] args) {

            Project project = null;
            try {
                XmlSerializer serializer = new XmlSerializer(typeof(Project));
                StreamReader reader = new StreamReader("./Project.xml");
                project = (Project)serializer.Deserialize(reader);
                reader.Close();
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
            //Obtain the total cost of the project  
            CostProjectVisitor costVisitor = new CostProjectVisitor();
            project.accept(costVisitor);
            double cost = (double) costVisitor.getResult();
            Console.WriteLine("Total cost > " + cost);

            //Get the sale price of the project  
            PriceProjectVisitor priceVisitor = new PriceProjectVisitor();
            project.accept(priceVisitor);
            double price = (double) priceVisitor.getResult();
            Console.WriteLine("Total price > " + price);
            Console.WriteLine("Total gain > " + (price - cost));

            //Show the total to pay per employee 
            Console.WriteLine("\n:::::::: Pay the workers :::::::");
            PaymentProjectVisitor paymentVisitor = new PaymentProjectVisitor();
            project.accept(paymentVisitor);
            List<EmployeePay> result = (List<EmployeePay>) paymentVisitor.getResult();
            foreach (EmployeePay pay in result) {
                Console.WriteLine(pay.getEmployeeName() + " > " + pay.getTotalPay());
            }
        }
    }
}