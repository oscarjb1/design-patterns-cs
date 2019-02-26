using System;
using System.Collections.Generic;

namespace oscarblancarte.ipd.mediator.module{

    public class ModuleMediator {

        private static ModuleMediator mediator;

        private static readonly Dictionary<String, AbstractModule> modules = new Dictionary<String, AbstractModule>();

        private ModuleMediator() {
        }

        public static ModuleMediator getInstance() {
            if (mediator == null) {
                mediator = new ModuleMediator();
            }
            return mediator;
        }

        public void registModule(AbstractModule module) {
            modules.Add(module.getModulName(), module);
        }

        public Object mediate(ModuleMessage mediateEvent) {
            if (!modules.ContainsKey(mediateEvent.getTarget())) {
                throw new SystemException("The module '" + mediateEvent.getTarget() + "' it's not registered");
            }
            Console.WriteLine("Mediate source > '" + mediateEvent.getSource()
                    + "', target > '" + mediateEvent.getTarget() 
                    + "', messagetType > '"+mediateEvent.getMessageType()+"'");
            AbstractModule module = modules[mediateEvent.getTarget()];
            return module.notifyMessage(mediateEvent);
        }
    }

}


