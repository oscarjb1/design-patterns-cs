using oscarblancarte.ipd.visitor.domain;
using System;

namespace oscarblancarte.ipd.visitor.impl{
    public class CostProjectVisitor : IVisitor {

        private double TotalCost;

        public void Project(Project project) {
            foreach (Activitie act in project.GetActivities()) {
                act.accept(this);
            }
        }

        public void Activitie(oscarblancarte.ipd.visitor.domain.Activitie activitie) {
            activitie.Responsible.accept(this);
            foreach (Activitie act in activitie.GetActivities()) {
                act.accept(this);
            }
        }

        public void Employee(Employee employee) {
            TotalCost += employee.Price;
        }

        public Object GetResult() {
            return TotalCost;
        }
    }
}



