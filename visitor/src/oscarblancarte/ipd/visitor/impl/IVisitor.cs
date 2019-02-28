using System;
using oscarblancarte.ipd.visitor.domain;

namespace oscarblancarte.ipd.visitor.impl{
    public interface IVisitor {
        void Project(Project project);
        void Activitie(Activitie activitie);
        void Employee(Employee employee);
        Object GetResult();
    }
}