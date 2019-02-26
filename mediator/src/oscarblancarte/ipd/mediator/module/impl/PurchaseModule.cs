using oscarblancarte.ipd.mediator.module;
using System;

namespace oscarblancarte.ipd.mediator.module.impl{
    public class PurchaseModule : AbstractModule {

        public static readonly String MODULE_NAME = "Chopping";
        public const String OPERATION_PURCHASE_REQUEST = "PurchaseRequest";

        public override string getModulName() {
            return MODULE_NAME;
        }

        public override Object notifyMessage(ModuleMessage message) {
            switch (message.getMessageType()) {
                case OPERATION_PURCHASE_REQUEST:
                    return purchaseRequest(message);
                default:
                    throw new SystemException("Operation not supported '" + message.getMessageType() + "'");
            }
        }

        private Object purchaseRequest(ModuleMessage message){
            return null;
        }
    }

}



