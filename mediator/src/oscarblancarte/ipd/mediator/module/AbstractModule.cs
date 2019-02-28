using System;

namespace oscarblancarte.ipd.mediator.module{
    public abstract class AbstractModule {

        protected ModuleMediator Mediator;

        public abstract string GetModulName();

        public void Activate() {
            Mediator = ModuleMediator.getInstance();
            Mediator.RegistModule(this);
        }

        public abstract Object NotifyMessage(ModuleMessage message);
    }
}

