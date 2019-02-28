namespace oscarblancarte.ipd.mediator.module.impl.dto{
    public class SaleOrder : Sale {

        public string Id{get; set;}

        public SaleOrder(string Id) {
            this.Id = Id;
        }
    }
}