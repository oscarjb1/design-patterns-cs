using System;
using oscarblancarte.ipd.abstractfactory.impl;
using oscarblancarte.ipd.abstractfactory.service;

namespace oscarblancarte.ipd.abstractfactory
{
    class AbstractFactoryMain
    {
        static void Main(string[] args)
        {
            IServiceStackAbstractFactory factory = ServiceStackAbstractFactory.CreateServiceFactory();
            IEmployeeService employeeService = factory.GetEmployeeService();
            IProductsService productService = factory.GetProductsService();

            Console.WriteLine("EmployeeService class > " + typeof(IEmployeeService).Name );
            Console.WriteLine("ProductService class  > " + typeof(IProductsService).Name);

            Console.WriteLine("getEmployee > " + string.Join("", employeeService.GetEmployee()));
            Console.WriteLine("getProduct  > " + string.Join("", productService.GetProducts()));

        }
    }
}