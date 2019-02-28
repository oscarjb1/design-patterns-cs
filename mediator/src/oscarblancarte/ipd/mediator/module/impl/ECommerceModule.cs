using oscarblancarte.ipd.mediator.module;
using oscarblancarte.ipd.mediator.module.impl.dto;
using System;

namespace oscarblancarte.ipd.mediator.module.impl{
    public class ECommerceModule : AbstractModule {

        public static readonly string MODULE_NAME = "ECommerce";

        public const string OPERATION_COMPLETE_ORDER = "CompleteOrder";

        public override string GetModulName() {
            return MODULE_NAME;
        }

        public override Object NotifyMessage(ModuleMessage message) {
            switch (message.MessageType) {
                case OPERATION_COMPLETE_ORDER:
                    return compleOrder(message);
                default:
                    throw new SystemException("Operation not supported '" + message.MessageType + "'");
            }
        }
        
        private String compleOrder(ModuleMessage message){
            SaleOrder saleOrder = (SaleOrder)message.Payload;
            Console.WriteLine("Order completed successfully > " );
            
            ModuleMessage crmMessage = new ModuleMessage(MODULE_NAME, 
                    NotifyModule.MODULE_NAME, NotifyModule.OPERATION_NOTIFY, 
                    saleOrder);
            Mediator.Mediate(crmMessage);
            return saleOrder.Id;
        }
        
        public String createSale(Sale sale){
            ModuleMessage crmMessage = new ModuleMessage(MODULE_NAME, 
                    CRMModule.MODULE_NAME, CRMModule.OPERATION_CREATE_ORDER, sale);
            return Mediator.Mediate(crmMessage).ToString();
        }

    }

}



