using oscarblancarte.ipd.abstractfactory.util;
using System.Configuration;
using System;
using System.Collections.Generic;

namespace oscarblancarte.ipd.abstractfactory.impl
{
    public class ServiceStackAbstractFactory
    {
        public ServiceStackAbstractFactory() { }

        public static IServiceStackAbstractFactory CreateServiceFactory()
        {
            IDictionary<string,string> props = PropertiesUtil.LoadProperty("./AbstractFactoryConfiguration.properties");
            string factoryClass = props["serviceProductImplClass"].ToString();
            Type type = Type.GetType(factoryClass);
            Console.WriteLine("factoryClass ==> " + factoryClass);
            try
            {
                return (IServiceStackAbstractFactory) Activator.CreateInstance(type);
            }
            catch (Exception e)
            {   
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}


