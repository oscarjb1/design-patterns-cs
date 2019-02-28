using System;
using System.Collections.Generic;

namespace oscarblancarte.ipd.mediator.module{

    public class ModuleMediator {

        private static ModuleMediator Mediator;

        private static readonly Dictionary<String, AbstractModule> Modules = new Dictionary<String, AbstractModule>();

        private ModuleMediator() {
        }

        public static ModuleMediator getInstance() {
            if (Mediator == null) {
                Mediator = new ModuleMediator();
            }
            return Mediator;
        }

        public void RegistModule(AbstractModule module) {
            Modules.Add(module.GetModulName(), module);
        }

        public Object Mediate(ModuleMessage mediateEvent) {
            if (!Modules.ContainsKey(mediateEvent.Target)) {
                throw new SystemException("The module '" + mediateEvent.Target + "' it's not registered");
            }
            Console.WriteLine("Mediate source > '" + mediateEvent.Source
                    + "', target > '" + mediateEvent.Target
                    + "', messagetType > '"+mediateEvent.MessageType+"'");
            AbstractModule module = Modules[mediateEvent.Target];
            return module.NotifyMessage(mediateEvent);
        }
    }

}


