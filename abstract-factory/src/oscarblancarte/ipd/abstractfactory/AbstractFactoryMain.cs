using System;
using oscarblancarte.ipd.abstractfactory.impl;
using oscarblancarte.ipd.abstractfactory.service;

namespace oscarblancarte.ipd.abstractfactory
{
    class AbstractFactoryMain
    {
        static void Main(string[] args)
        {
            IServiceStackAbstractFactory factory = ServiceStackAbstractFactory.createServiceFactory();
            IEmployeeService employeeService = factory.getEmployeeService();
            IProductsService productService = factory.getProductsService();

            Console.WriteLine("EmployeeService class > " + typeof(IEmployeeService).Name );
            Console.WriteLine("ProductService class  > " + typeof(IProductsService).Name);

            Console.WriteLine("getEmployee > " + string.Join("", employeeService.getEmployee()));
            Console.WriteLine("getProduct  > " + string.Join("", productService.getProducts()));

        }
    }
}