using oscarblancarte.ipd.mediator.module;
using System;

namespace oscarblancarte.ipd.mediator.module.impl{
    public class PurchaseModule : AbstractModule {

        public static readonly String MODULE_NAME = "Chopping";
        public const String OPERATION_PURCHASE_REQUEST = "PurchaseRequest";

        public override string GetModulName() {
            return MODULE_NAME;
        }

        public override Object NotifyMessage(ModuleMessage message) {
            switch (message.MessageType) {
                case OPERATION_PURCHASE_REQUEST:
                    return PurchaseRequest(message);
                default:
                    throw new SystemException("Operation not supported '" + message.MessageType + "'");
            }
        }

        private Object PurchaseRequest(ModuleMessage message){
            return null;
        }
    }

}



