using oscarblancarte.ipd.mediator.module;
using System;
namespace oscarblancarte.ipd.mediator.module.impl{

    public class NotifyModule : AbstractModule {

        public static readonly string MODULE_NAME = "Notification";
        public const string OPERATION_NOTIFY = "Notify";

        public override string getModulName() {
            return MODULE_NAME;
        }

        public override Object notifyMessage(ModuleMessage message) {
            switch (message.getMessageType()) {
                case OPERATION_NOTIFY:
                    return notify(message);
                default:
                    throw new SystemException("Operation not supported '" + message.getMessageType() + "'");
            }
        }

        private Object notify(ModuleMessage message) {
            Console.WriteLine("Notification sent");
            return null;
        }

    }

}


