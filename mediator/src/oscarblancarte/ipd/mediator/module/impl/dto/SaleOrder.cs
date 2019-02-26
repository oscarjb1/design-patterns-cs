namespace oscarblancarte.ipd.mediator.module.impl.dto{
    public class SaleOrder : Sale {

        private string id;

        public SaleOrder(string id) {
            this.id = id;
        }

        public string getId() {
            return id;
        }

        public void setId(string id) {
            this.id = id;
        }
    }
}

