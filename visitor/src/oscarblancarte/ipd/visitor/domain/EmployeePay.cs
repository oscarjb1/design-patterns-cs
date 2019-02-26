namespace oscarblancarte.ipd.visitor.domain{
    public class EmployeePay {

        public string employeeName;
        public double totalPay;

        public EmployeePay(string employeeName, double totalPay) {
            this.employeeName = employeeName;
            this.totalPay = totalPay;
        }

        public string getEmployeeName() {
            return employeeName;
        }

        public void setEmployeeName(string employeeName) {
            this.employeeName = employeeName;
        }

        public double getTotalPay() {
            return totalPay;
        }

        public void setTotalPay(double totalPay) {
            this.totalPay = totalPay;
        }
    }
}