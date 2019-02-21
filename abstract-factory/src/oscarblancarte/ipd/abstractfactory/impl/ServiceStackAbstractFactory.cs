using oscarblancarte.ipd.abstractfactory.util;
using System.Configuration;
using System;
using System.Collections.Specialized;

namespace oscarblancarte.ipd.abstractfactory.impl
{
    public class ServiceStackAbstractFactory
    {
        public ServiceStackAbstractFactory() { }

        public static IServiceStackAbstractFactory createServiceFactory()
        {
            NameValueCollection props = PropertiesUtil.loadProperty();
            string factoryClass = ConfigurationManager.AppSettings["serviceProductImplClass"].ToString();
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


