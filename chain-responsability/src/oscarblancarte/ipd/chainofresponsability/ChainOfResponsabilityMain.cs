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
            salesOrder.setDeliveryDate(DateTime.Now);
            Customer customer = new Customer();
            customer.setName("Oscar Blancarte");
            customer.setRfc("XXX0000000X0");
            customer.setStatus(Status.ACTIVO);

            Telephone phone = new Telephone();
            phone.setExt("123");
            phone.setLada("999");
            phone.setNumber("1234567");
            customer.setTelephone(phone);

            Address address = new Address();
            address.setAddress1("Address 1");
            address.setAddress2("Address 2");
            address.setCP("1234");
            address.setCountry("Mexico");
            customer.setAddress(address);

            CreditData creditData = new CreditData();
            creditData.setBalance(1000);
            creditData.setCreditLimit(13000);
            customer.setCreditData(creditData);

            salesOrder.setContributor(customer);

            List<OrderItem> orderItems = new List<OrderItem>();
            for (int c = 0; c < 10; c++) {
                OrderItem item = new OrderItem();
                item.setPrice((c + 1) * 30);
                Product product = new Product();
                product.setListPrice((c + 1) * 32);
                product.setName("Product " + (c + 1));
                item.setProduct(product);
                item.setQuantity(1);
                orderItems.Add(item);
            }
            salesOrder.setOrderItems(orderItems);
            Console.WriteLine("Total orden > " + salesOrder.getTotal());
            try {
                AbstractOrderValidator validator = OrderValidatorBuilder.buildSalesOrderValidator();
                validator.validate(salesOrder);
                Console.WriteLine("Successful validation");
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
    }

}


