using oscarblancarte.ipd.chainofresponsability.domain;
using oscarblancarte.ipd.chainofresponsability.domain.order;
using oscarblancarte.ipd.chainofresponsability.validator;
using System;
using System.Collections.Generic;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.chainofresponsability{
    public class ChainOfResponsabilityMain {

        static void Main(string[] args) {
            SalesOrder salesOrder = new SalesOrder();
            salesOrder.DeliveryDate = DateTime.Now;
            Customer customer = new Customer();
            customer.Name = "Oscar Blancarte";
            customer.Rfc = "XXX0000000X0";
            customer.Status = Status.ACTIVO;

            Telephone phone = new Telephone();
            phone.Ext = "123";
            phone.Lada = "999";
            phone.Number = "1234567";
            customer.Telephone = phone;

            Address address = new Address();
            address.Address1 = "Address 1";
            address.Address2 = "Address 2";
            address.CP = "1234";
            address.Country = "Mexico";
            customer.Address = address;

            CreditData creditData = new CreditData();
            creditData.Balance = 1000;
            creditData.CreditLimit = 13000;
            customer.CreditData = creditData;

            salesOrder.Contributor = customer;

            List<OrderItem> orderItems = new List<OrderItem>();
            for (int c = 0; c < 10; c++) {
                OrderItem item = new OrderItem();
                item.Price = (c + 1) * 30;
                Product product = new Product();
                product.ListPrice = (c + 1) * 32;
                product.Name = "Product " + (c + 1);
                item.Product = product;
                item.Quantity = 1;
                orderItems.Add(item);
            }
            salesOrder.OrderItems  = orderItems;
            Console.WriteLine("Total orden > " + salesOrder.getTotal());
            try {
                AbstractOrderValidator validator = OrderValidatorBuilder.BuildSalesOrderValidator();
                validator.Validate(salesOrder);
                Console.WriteLine("Successful validation");
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
    }

}


