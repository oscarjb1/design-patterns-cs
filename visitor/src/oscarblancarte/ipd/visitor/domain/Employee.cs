using oscarblancarte.ipd.visitor.impl;
using System;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;



namespace oscarblancarte.ipd.visitor.domain{


    [XmlRoot(ElementName="responsible")]
	public class Employee {

        public Employee() {
        }

        public Employee(string name, double price) {
            this.Name = name;
            this.Price = price;
        }

		[XmlAttribute(AttributeName="name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName="price")]
		public double Price { get; set; }

        public void accept(IVisitor visitor) {
            visitor.employee(this);
        }
	}
}