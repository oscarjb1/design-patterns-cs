using System;

namespace oscarblancarte.ipd.visitor.impl{
    public interface IVisitable {
        void accept(IVisitor visitor);
    }
}