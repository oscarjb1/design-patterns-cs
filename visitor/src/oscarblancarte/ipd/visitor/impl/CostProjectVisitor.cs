using oscarblancarte.ipd.visitor.domain;
using System;

namespace oscarblancarte.ipd.visitor.impl{
    public class CostProjectVisitor : IVisitor {

        private double totalCost;

        public void project(Project project) {
            foreach (Activitie act in project.GetActivities()) {
                act.accept(this);
            }
        }

        public void activitie(oscarblancarte.ipd.visitor.domain.Activitie activitie) {
            activitie.Responsible.accept(this);
            foreach (Activitie act in activitie.GetActivities()) {
                act.accept(this);
            }
        }

        public void employee(Employee employee) {
            totalCost += employee.Price;
        }

        public Object getResult() {
            return totalCost;
        }
    }
}



