using oscarblancarte.ipd.visitor.domain;
using System;

namespace oscarblancarte.ipd.visitor.impl{

    public class PriceProjectVisitor : IVisitor {

        private double totalPrice;

        public void Project(Project project) {
            foreach (Activitie act in project.Activities) {
                act.accept(this);
            }
        }

        public void Activitie(oscarblancarte.ipd.visitor.domain.Activitie activitie) {
            totalPrice += activitie.Price;
            foreach (Activitie act in activitie.Activities) {
                act.accept(this);
            }
        }

        public void Employee(Employee employee) {
            // Not Interesting for this Visitor  
        }

        public Object GetResult() {
            return totalPrice;
        }
    }

}