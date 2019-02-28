using System.Collections.Generic;
using oscarblancarte.ipd.visitor.impl;
using System;
using System.Xml.Serialization;


		
namespace oscarblancarte.ipd.visitor.domain{

    [XmlRoot(ElementName="Project")]
	public class Project {
		[XmlElement(ElementName="Activities")]
		public List<Activitie> Activities { get; set; }
        
		[XmlAttribute(AttributeName="name")]
		public string Name { get; set; }


        public void accept(IVisitor visitor) {
            visitor.Project(this);
        }

        public List<Activitie> GetActivities() {
            if(this.Activities==null){
                this.Activities = new List<Activitie>();
            }
            return Activities;
        }

	}

}


