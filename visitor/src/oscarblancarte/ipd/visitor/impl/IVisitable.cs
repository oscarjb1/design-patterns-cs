using System;

namespace oscarblancarte.ipd.visitor.impl{
    public interface IVisitable {
        void Accept(IVisitor visitor);
    }
}