using oscarblancarte.ipd.mediator.module;
using oscarblancarte.ipd.mediator.module.impl.dto;
using System;

namespace oscarblancarte.ipd.mediator.module.impl{
    public class ECommerceModule : AbstractModule {

        public static readonly string MODULE_NAME = "ECommerce";

        public const string OPERATION_COMPLETE_ORDER = "CompleteOrder";

        public override string getModulName() {
            return MODULE_NAME;
        }

        public override Object notifyMessage(ModuleMessage message) {
            switch (message.getMessageType()) {
                case OPERATION_COMPLETE_ORDER:
                    return compleOrder(message);
                default:
                    throw new SystemException("Operation not supported '" + message.getMessageType() + "'");
            }
        }
        
        private String compleOrder(ModuleMessage message){
            SaleOrder saleOrder = (SaleOrder)message.getPayload();
            Console.WriteLine("Order completed successfully > " );
            
            ModuleMessage crmMessage = new ModuleMessage(MODULE_NAME, 
                    NotifyModule.MODULE_NAME, NotifyModule.OPERATION_NOTIFY, 
                    saleOrder);
            mediator.mediate(crmMessage);
            return saleOrder.getId();
        }
        
        public String createSale(Sale sale){
            ModuleMessage crmMessage = new ModuleMessage(MODULE_NAME, 
                    CRMModule.MODULE_NAME, CRMModule.OPERATION_CREATE_ORDER, sale);
            return mediator.mediate(crmMessage).ToString();
        }

    }

}



