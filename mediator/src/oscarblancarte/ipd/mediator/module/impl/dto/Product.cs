namespace oscarblancarte.ipd.mediator.module.impl.dto{
    public class Product {
        private string name;

        public Product(string name) {
            this.name = name;
        }

        public string getName() {
            return name;
        }

        public void setName(string name) {
            this.name = name;
        }
    }

}

