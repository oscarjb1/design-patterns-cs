
using oscarblancarte.ipd.mediator.module;
using oscarblancarte.ipd.mediator.module.impl.dto;
using System;
using System.Threading;

namespace oscarblancarte.ipd.mediator.module.impl{
    public class CRMModule : AbstractModule {

        public static readonly string MODULE_NAME = "CRM";

        public const string OPERATION_CREATE_ORDER = "CreateOrder";

        public override string getModulName() {
            return MODULE_NAME;
        }

        public override Object notifyMessage(ModuleMessage message) {
            switch (message.getMessageType()) {
                case OPERATION_CREATE_ORDER:
                    return createSaleOrder(message);
                default:
                    throw new SystemException("Operation not supported '" + message.getMessageType() + "'");
            }
        }

        public void StartThread(SaleOrder saleOrder){
            try {
                Thread.Sleep(1000 * 10);
                ModuleMessage stockEvent = new ModuleMessage(MODULE_NAME, ECommerceModule.MODULE_NAME, ECommerceModule.OPERATION_COMPLETE_ORDER, saleOrder);
                mediator.mediate(stockEvent);
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }

        private string createSaleOrder(ModuleMessage message) {
            Sale sale = (Sale) message.getPayload();
            string ID = System.Guid.NewGuid().ToString();
            
            Console.WriteLine("Sales order successfully created");
            SaleOrder saleOrder = new SaleOrder(ID);
            saleOrder.setProductos(sale.getProductos());

            ModuleMessage stockEvent = new ModuleMessage(MODULE_NAME, StockModule.MODULE_NAME, StockModule.OPERATION_DECREMENT_STOCK, saleOrder);
            mediator.mediate(stockEvent);

            Thread thread = new Thread(() => StartThread(saleOrder));
            thread.Start();

            return ID;
        }
    }
}