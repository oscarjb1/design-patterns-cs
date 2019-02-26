using System.Collections.Generic;
using oscarblancarte.ipd.visitor.impl;
using System;
using System.Xml.Serialization;
		
namespace oscarblancarte.ipd.visitor.domain{

    [XmlRoot(ElementName="Activities")]
	public class Activitie {
		[XmlElement(ElementName="responsible")]
		public Employee Responsible { get; set; }

		[XmlAttribute(AttributeName="name")]
		public string Name { get; set; }

		[XmlAttribute(AttributeName="price")]
		public double Price { get; set; }

		[XmlElement(ElementName="Activities")]
		public List<Activitie> Activities { get; set; }

        public Activitie() {
        }

        public Activitie(string name, Int64 price, Employee responsible) {
            this.Name = name;
            this.Price = price;
            this.Responsible = responsible;
        }

        public List<Activitie> GetActivities() {
            if (this.Activities == null) {
                this.Activities = new List<Activitie>();
            }
            return Activities;
        }


        public void addActivitie(Activitie Activities) {
            if (this.Activities == null) {
                this.Activities = new List<Activitie>();
            }
            this.Activities.Add(Activities);
        }

        public void removeActivitie(Activitie Activities) {
            if (this.Activities == null) {
                this.Activities = new List<Activitie>();
            }
            this.Activities.Remove(Activities);
        }

        public void accept(IVisitor visitor) {
            visitor.activitie(this);
        }
        
	}
}