using System;
using oscarblancarte.ipd.visitor.domain;

namespace oscarblancarte.ipd.visitor.impl{
    public interface IVisitor {
        void project(Project project);
        void activitie(Activitie activitie);
        void employee(Employee employee);
        Object getResult();
    }
}