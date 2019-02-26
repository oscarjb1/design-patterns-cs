using oscarblancarte.ipd.mediator.module;
using oscarblancarte.ipd.mediator.module.impl.dto;
using System;

namespace oscarblancarte.ipd.mediator.module.impl{
    public class StockModule : AbstractModule {

        public static readonly string MODULE_NAME = "Stock";
        public const string OPERATION_DECREMENT_STOCK = "DecrementStock";

        public override string getModulName() {
            return MODULE_NAME;
        }

        public override Object notifyMessage(ModuleMessage message) {
            switch (message.getMessageType()) {
                case OPERATION_DECREMENT_STOCK:
                    return decrementStock(message);
                default:
                    throw new SystemException("Operation not supported '" + message.getMessageType() + "'");
            }
        }

        private Object decrementStock(ModuleMessage message) {
            SaleOrder saleOrder = (SaleOrder) message.getPayload();
            foreach(Product product in saleOrder.getProductos()) {
                Console.WriteLine("decrement product > " + product.getName());
            }
            
            ProductRequest productRequest = new ProductRequest();
            productRequest.setProducts(saleOrder.getProductos());
            
            ModuleMessage purchaseMessage = new ModuleMessage(MODULE_NAME, 
                    PurchaseModule.MODULE_NAME, 
                    PurchaseModule.OPERATION_PURCHASE_REQUEST, productRequest);
            mediator.mediate(purchaseMessage);
            return null;
            
        }
    }

}



